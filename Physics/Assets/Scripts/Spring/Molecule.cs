using System.Collections.Generic;
using Physics.Acceleration;
using Physics.Forces;
using UnityEngine;

namespace Physics.Spring
{
    public class Molecule : MonoBehaviour
    {
        public MovementT2 Movement;

        public Force Force;

        public bool IsMiddle;

        void Start()
        {
            Movement = GetComponent<MovementT2>();
            Force = GetComponent<Force>();
            
            Force.ActingForces = new List<Vector3>();
            Force.ActingForces.Add(new Vector3(0, 0, 0));
        }

        void FixedUpdate()
        {
            Movement.Accleration = Force.Acceleration();
        }
    }
}