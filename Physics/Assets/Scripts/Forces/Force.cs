using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Physics.Enums;
using UnityEngine;

namespace Physics.Forces
{
    public class Force : MonoBehaviour
    {
        /// <summary>
        /// All forces acting on the object
        /// </summary>
        public List<Vector3> ActingForces;

        /// <summary>
        /// Weight of this object
        /// </summary>
        public float Mass;

        /// <summary>
        /// Sum of all forces acting on the object
        /// </summary>
        /// <returns></returns>
        public Vector3 ResultantForce()
        {
            return ActingForces.Aggregate(
                new Vector3(0, 0, 0),
                (seed, vector) => seed + vector
            );
        }

        /// <summary>
        /// Acceleration of this object<br/>
        /// a = Fr / M<br/>
        /// accleration = resultant force / mass
        /// </summary>
        /// <returns></returns>
        public Vector3 Acceleration()
        {
            var resultantForce = ResultantForce();
            
            return resultantForce / Mass;
        }

        /// <summary>
        /// Get accleration from a specific axis
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float Acceleration(AxisEnum index)
        {
            var resultantForce = ResultantForce();
            
            return resultantForce[(int)index] / Mass;
        }
    }
}