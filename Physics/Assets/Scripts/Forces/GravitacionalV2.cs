using System.Collections.Generic;
using Physics.Acceleration;
using Physics.Forces;
using UnityEngine;

namespace Physics.Assets.Scripts.Forces
{
    /// <summary>
    /// <seealso cref="https://mikhail-szugalew.medium.com/simulating-gravity-in-unity-ae8258a80b6d"/>
    /// </summary>
    public class GravitacionalV2 : MonoBehaviour
    {
        public GameObject Sun;

        public Vector3 SunPosition;

        public float SunMass = 100000000000.0f;
             
        public GameObject Planet;

        public Vector3 StartVelocity = new Vector3(0f, 5f, 0f);

        public Vector3 PlanetPosition;

        public float PlanetMass = 10f;

        public Rigidbody PlanetRigidBody;

        public Vector3 OriginalPosition;

        public Vector3 NewPosition;

        public Vector3 Velocity;

        public Vector3 Acceleration;

        void Start()
        {
            PlanetRigidBody = Planet.GetComponent<Rigidbody>();
            PlanetRigidBody.AddForce(StartVelocity, ForceMode.VelocityChange);
        }

        void Update()
        {
            PlanetRigidBody.AddForce(CalculateForce() * 0.1f, ForceMode.Impulse);
        }

        void FixedUpdate()
        {
            float time = 0.001f;

            OriginalPosition = Planet.transform.position;

            Acceleration = CalculateForce() / PlanetMass;

            Planet.transform.position += (Velocity * time + 0.5f * Acceleration * time * time);

            NewPosition = Planet.transform.position;

            Velocity = (NewPosition - OriginalPosition) / time;
        }

        private Vector3 CalculateForce()
        {
            SunPosition = Sun.transform.position;
            PlanetPosition = Planet.transform.position;

            float distance = Vector3.Distance(SunPosition, PlanetPosition);
            float distanceSquared = distance * distance;
            float gravitacionalConstant = 6.67f * Mathf.Pow(10, -11);

            float force = (gravitacionalConstant * SunMass * PlanetMass) / distanceSquared;

            Vector3 heading = (SunPosition - PlanetPosition);

            return (force * (heading / heading.magnitude));
        }
   }
}