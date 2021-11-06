using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Physics.Colliders
{
    public class ColliderDetector : MonoBehaviour
    {
        public GameObject Sphere;

        public GameObject Sphere2;

        private float SphereCollider;

        private Vector3 SpherePosition;

        private float SphereCollider2;

        private Vector3 SpherePostion2;

        void Start()
        {
            SphereCollider = Sphere.transform.localScale.x;
            SphereCollider2 = Sphere2.transform.localScale.x;
        }

        void FixedUpdate()
        {
            SpherePosition = Sphere.transform.position;
            SpherePostion2 = Sphere2.transform.position;

            float Distance = Vector3.Distance(SpherePosition, SpherePostion2);

            var newColor = Distance <= (SphereCollider + SphereCollider2) / 2
                ? new Color(0, 255, 0)
                : new Color(0, 0, 0);

            GetComponent<Renderer>().material.color = newColor;
        }
    }
}

