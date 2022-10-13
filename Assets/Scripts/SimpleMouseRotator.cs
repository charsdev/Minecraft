using System;
using UnityEngine;

    public class SimpleMouseRotator : MonoBehaviour
    {
        public Vector2 rotationRange = new Vector3(30, 30);
        public float rotationSpeed = 10;
        public float dampingTime = 0.2f;
        private Vector3 m_TargetAngles;
        private Vector3 m_FollowAngles;
        private Vector3 m_FollowVelocity;
        private Quaternion m_OriginalRotation;


        private void Start()
        {
            m_OriginalRotation = transform.localRotation;
        }


        private void Update()
        {
            transform.localRotation = m_OriginalRotation;
            var input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            if (m_TargetAngles.y > 180)
            {
                m_TargetAngles.y -= 360;
                m_FollowAngles.y -= 360;
            }
            if (m_TargetAngles.x > 180)
            {
                m_TargetAngles.x -= 360;
                m_FollowAngles.x -= 360;
            }
            if (m_TargetAngles.y < -180)
            {
                m_TargetAngles.y += 360;
                m_FollowAngles.y += 360;
            }
            if (m_TargetAngles.x < -180)
            {
                m_TargetAngles.x += 360;
                m_FollowAngles.x += 360;
            }

            m_TargetAngles.y += input.x * rotationSpeed;
            m_TargetAngles.x += input.y * rotationSpeed;

            m_TargetAngles.y = Mathf.Clamp(m_TargetAngles.y, -rotationRange.y*0.5f, rotationRange.y*0.5f);
            m_TargetAngles.x = Mathf.Clamp(m_TargetAngles.x, -rotationRange.x*0.5f, rotationRange.x*0.5f);
        

            m_FollowAngles = Vector3.SmoothDamp(m_FollowAngles, m_TargetAngles, ref m_FollowVelocity, dampingTime);

            transform.localRotation = m_OriginalRotation*Quaternion.Euler(-m_FollowAngles.x, 0f, m_FollowAngles.y);
        }
    }

