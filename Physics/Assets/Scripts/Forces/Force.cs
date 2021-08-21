using System.Collections;
using System.Collections.Generic;
using Physics.Enums;
using UnityEngine;

namespace Physics.Forces
{
    public class Force : MonoBehaviour
    {
        public Vector3 Force1;

        public Vector3 Force2;

        public Vector3 Force3;

        public float Mass;

        public Vector3 ResultantForce()
        {
            return Force1 + Force2 + Force3;
        }

        public float Acceleration(AxisEnum index)
        {
            var resultantForce = ResultantForce();
            
            return ((resultantForce[(int)index] / Mass));
        }
    }
}