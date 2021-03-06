using Physics.Acceleration;
using Physics.Forces;
using UnityEngine;

namespace Physics.Assets.Scripts.Forces
{
    public class AirResistence : MonoBehaviour
    {
        public bool UseDamp;
        
        public float FluidDensity;

        public float Aerodynamics;
        
        public float Area 
        {
            get
            {
                return Mathf.PI * Mathf.Pow((transform.localScale.x / 2), 2);
            }
        }
        
        public MovementT2 Movement;

        public Force Force;

        void Start()
        {
            Force = GetComponent<Force>();
            Movement = GetComponent<MovementT2>();
        }

        void FixedUpdate()
        {
            if (!UseDamp)
                return;

            if (Force.ActingForces?.Count > 0)
                Force.ActingForces[0] = EnduranceForce();
        }

        public Vector3 EnduranceForce()
        {
            var newVelocity = new Vector3(
                Mathf.Pow(Movement.Velocity.x, 2),
                Mathf.Pow(Movement.Velocity.y, 2),
                Mathf.Pow(Movement.Velocity.z, 2)
            );

            return ((0.5f * FluidDensity) * Aerodynamics * Area) * newVelocity; 
        }
    }
}