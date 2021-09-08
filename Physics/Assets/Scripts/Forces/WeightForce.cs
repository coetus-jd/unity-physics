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

        private void SetWeightForce()
        {
            var weightForce = Force.Mass * Force.ResultantForce();
            Force.Forces.Add(weightForce);

            Movement.accleration = Force.Acceleration();
        }
    }
}