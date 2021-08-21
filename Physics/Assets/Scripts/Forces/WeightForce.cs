using System.Collections;
using System.Collections.Generic;
using Physics.Acceleration;
using Physics.Enums;
using UnityEngine;

namespace Physics.Forces
{
    public class WeightForce : MonoBehaviour
    {
        private Force force;

        private MovementT2 movement;

        void Start()
        {
            force = GetComponent<Force>();
            movement = GetComponent<MovementT2>();

            movement.accleration = new Vector3(
                force.Acceleration(AxisEnum.x),
                force.Acceleration(AxisEnum.y),
                force.Acceleration(AxisEnum.z)
            );
        }

        void FixedUpdate()
        {
            // Debug.Log(force.Acceleration(AxisEnum.y));
            transform.position += new Vector3(
                0, force.Mass * force.Acceleration(AxisEnum.y) * Time.deltaTime, 0
            );
        }
    }
}