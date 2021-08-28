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
            // movement = GetComponent<MovementT2>();
        }

        void FixedUpdate()
        {
            transform.position += new Vector3(
                0, force.Mass * force.ResultantForce().y * Time.deltaTime, 0
            );
        }
    }
}