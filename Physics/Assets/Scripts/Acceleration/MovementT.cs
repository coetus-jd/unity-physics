using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Physics.Acceleration
{
    public class MovementT : MonoBehaviour
    {
        public Vector3 velocity;

        public Vector3 accleration;

        void FixedUpdate()
        {
            UpdateVelocity();

            transform.position = CalculatePosition();
        }

        private Vector3 CalculatePosition()
        {
            return ((transform.position + velocity) * Time.deltaTime);
        }

        private void UpdateVelocity()
        {
            velocity += accleration * Time.deltaTime;
        }
    }
}
