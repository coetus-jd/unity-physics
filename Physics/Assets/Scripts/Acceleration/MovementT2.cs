using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Physics.Acceleration
{
    public class MovementT2 : MonoBehaviour
    {
        public Vector3 Velocity;

        public Vector3 Accleration;

        void FixedUpdate()
        {
            transform.position = CalculatePosition();
            UpdateVelocity();
        }

        private Vector3 CalculatePosition()
        {
            return (
                transform.position
                + (Velocity * Time.deltaTime)
                + (Accleration * Time.deltaTime / 2)
            );
        }

        private void UpdateVelocity()
        {
            Velocity += Accleration * Time.deltaTime;
        }
    }

}
