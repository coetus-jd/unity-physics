using Physics.Acceleration;
using Physics.Forces;
using UnityEngine;

namespace Physics.Spring
{
    public class Molecule : MonoBehaviour
    {
        public MovementT2 Movement;

        public Force Force;

        void Start()
        {
            Movement = GetComponent<MovementT2>();
            Force = GetComponent<Force>();
        }

        void FixedUpdate()
        {
            Movement.accleration = Force.Acceleration();
        }
    }
}