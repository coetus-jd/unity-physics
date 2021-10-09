using System.Collections;
using System.Collections.Generic;
using Physics.Acceleration;
using Physics.Enums;
using UnityEngine;

namespace Physics.Forces
{
    public class WeightForce : MonoBehaviour
    {
        private Force Force;

        private MovementT2 Movement;

        void Start()
        {
            Force = GetComponent<Force>();
            Movement = GetComponent<MovementT2>();
            SetWeightForce();
        }

        private void FixedUpdate()
        {
            Movement.Accleration = Force.Acceleration();
        }

        private void SetWeightForce()
        {
            var weightForce = Force.Mass * new Vector3(0, -9.81f, 0);
            Force.ActingForces.Add(weightForce);

            Movement.Accleration = Force.Acceleration();
        }
    }
}