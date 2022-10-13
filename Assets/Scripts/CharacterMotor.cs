using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    [Header("Motors")]
    public TPSMotor tpsMotor;
    public FPSMotor fpsMotor;

    [Header("Jump Settings")]
    public float JumpForce = 12f;
    private bool m_Jump;
    private bool m_PreviouslyGrounded;
    public bool m_IsGrounded;
    private Rigidbody m_RigidBody;
    private CapsuleCollider m_Capsule;
    public float shellOffset;

    [Header("Sound Settings")]
    private float m_StepCycle;
    private float m_NextStep;
    private AudioSource m_AudioSource;
    public AudioClip[] m_FootstepSounds;
    public AudioClip jumpSound;
    public AudioClip landSound;

    public float m_StepInterval;

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        m_Capsule = GetComponent<CapsuleCollider>();
        m_AudioSource = GetComponent<AudioSource>();
        m_StepCycle = 0f;
        m_NextStep = m_StepCycle / 2f;
    }

    private void FixedUpdate()
    {
        GroundCheck();
        if (m_IsGrounded)
        {
            m_RigidBody.drag = 5f;
            if (m_Jump)
            {
                PlayJumpSound();
                m_RigidBody.drag = 0f;
                m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, m_RigidBody.velocity.z);
                m_RigidBody.AddForce(new Vector3(0f, JumpForce, 0f), ForceMode.Impulse);
            }
        }
        else
        {
            m_RigidBody.drag = 0f;
        }

        m_Jump = false;
        ProgressStepCycle(1);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            tpsMotor.enabled = !tpsMotor.enabled;
            fpsMotor.enabled = !fpsMotor.enabled;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !m_Jump)
        {
            m_Jump = true;
        }
    }

    private void GroundCheck()
    {
        m_PreviouslyGrounded = m_IsGrounded;
        RaycastHit hitInfo;
        m_IsGrounded = Physics.SphereCast(transform.position, m_Capsule.radius * (1.0f - shellOffset), Vector3.down, out hitInfo,
                               ((m_Capsule.height / 2f) - m_Capsule.radius) + 0.01f, Physics.AllLayers, QueryTriggerInteraction.Ignore);

        if (!m_PreviouslyGrounded && m_IsGrounded)
        {
            PlayLandingSound();
        }
    }

    private void PlayLandingSound()
    {
        m_AudioSource.PlayOneShot(landSound);
        m_NextStep = m_StepCycle + .5f;
    }


    private void PlayJumpSound()
    {
        m_AudioSource.PlayOneShot(jumpSound);
    }


    private void ProgressStepCycle(float speed)
    {
        var input = Input.GetAxis("Horizontal") + Input.GetAxis("Vertical");

        if (m_RigidBody.velocity.sqrMagnitude > 0 && input != 0)
        {
            m_StepCycle +=  speed * Time.fixedDeltaTime;
        }

        if (!(m_StepCycle > m_NextStep))
        {
            return;
        }

        m_NextStep = m_StepCycle + m_StepInterval;

        PlayFootStepAudio();
    }


    private void PlayFootStepAudio()
    {
        if (!m_IsGrounded)
        {
            return;
        }
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }





}
