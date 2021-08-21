using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Physics.Acceleration
{
    public class MovementT2 : MonoBehaviour
    {
        [SerializeField]
        private Vector3 velocity;

        [SerializeField]
        private Vector3 accleration;

        void FixedUpdate()
        {
            UpdateVelocity();

            transform.position = new Vector3(
                CalculatePosition(transform.position.x),
                transform.position.y,
                transform.position.z
            );
        }

        private float CalculatePosition(float positionX)
        {
            return positionX
                + velocity.x * Time.deltaTime
                + (accleration.x * Time.deltaTime / 2);
        }

        private void UpdateVelocity()
        {
            velocity += accleration * Time.deltaTime;
        }
    }

}
