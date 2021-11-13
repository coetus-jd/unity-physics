using System.Collections;
using System.Collections.Generic;
using Physics.Acceleration;
using Physics.Elastic;
using UnityEngine;

namespace Physics.Colliders
{
    public class SphereColliderDetector : MonoBehaviour
    {
        [Header("Sphere 1")]
        public GameObject Sphere;

        [SerializeField]
        private float SphereMass;

        private float SphereCollider;

        private Vector3 SpherePosition;

        [Header("Sphere 2")]
        public GameObject Sphere2;

        [SerializeField]
        private float SphereMass2;

        private float SphereCollider2;

        private Vector3 SpherePostion2;

        [Header("Collision")]
        [SerializeField]
        private bool IsPerfectElasticCollision;

        private bool Collided;

        private bool CalculatedCollision;

        private PerfectInelasticCollision PerfectInelasticCollision;

        private PerfectElasticCollision PerfectElasticCollision;

        void Start()
        {
            PerfectInelasticCollision = new PerfectInelasticCollision();
            PerfectElasticCollision = new PerfectElasticCollision();

            SphereCollider = Sphere.transform.localScale.x;
            SphereCollider2 = Sphere2.transform.localScale.x;
        }

        void FixedUpdate()
        {
            SpherePosition = Sphere.transform.position;
            SpherePostion2 = Sphere2.transform.position;

            float Distance = Vector3.Distance(SpherePosition, SpherePostion2);

            Collided = Distance <= (SphereCollider + SphereCollider2) / 2;

            HandleCollision();

            if (Collided) Debug.Log("Colidiu");

            var newColor = Collided
                ? new Color(0, 255, 0)
                : new Color(0, 0, 0);

            GetComponent<Renderer>().material.color = newColor;
        }


        private void HandleCollision()
        {
            if (!Collided || CalculatedCollision)
                return;

            var sphereMovement = Sphere.GetComponent<MovementT2>();
            var sphereMovement2 = Sphere2.GetComponent<MovementT2>();
            
            CalculatedCollision = true;

            if (!IsPerfectElasticCollision)
            {
                sphereMovement2.Velocity.x = PerfectInelasticCollision.CalculateVelocitySecondObject(
                    SphereMass,
                    SphereMass2,
                    sphereMovement.Velocity.x
                );

                sphereMovement.Velocity.x = PerfectInelasticCollision.CalculateVelocityFirstObject(
                    SphereMass,
                    SphereMass2,
                    sphereMovement.Velocity.x
                );
                return;
            }

            sphereMovement2.Velocity.x = PerfectElasticCollision.CalculateVelocitySecondObject(
                SphereMass,
                SphereMass2,
                sphereMovement.Velocity.x
            );

            sphereMovement.Velocity.x = PerfectElasticCollision.CalculateVelocityFirstObject(
                SphereMass,
                SphereMass2,
                sphereMovement.Velocity.x
            );
        }
    }
}

