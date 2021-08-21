using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Physics.Acceleration
{
    public class MovementT2 : MonoBehaviour
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
            return (
                transform.position
                + (velocity * Time.deltaTime)
                + (accleration * Time.deltaTime / 2)
            );
        }

        private void UpdateVelocity()
        {
            velocity += accleration * Time.deltaTime;
        }
    }

}
