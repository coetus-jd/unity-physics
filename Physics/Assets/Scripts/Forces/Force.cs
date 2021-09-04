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

        /// <summary>
        /// Realiza a soma vetorial em todos os eixos (x, y, z)
        /// </summary>
        /// <returns></returns>
        public Vector3 ResultantForce()
        {
            return Force1 + Force2 + Force3;
        }

        public Vector3 Acceleration()
        {
            var resultantForce = ResultantForce();
            
            return resultantForce / Mass;
        }

        public float Acceleration(AxisEnum index)
        {
            var resultantForce = ResultantForce();
            
            return resultantForce[(int)index] / Mass;
        }
    }
}