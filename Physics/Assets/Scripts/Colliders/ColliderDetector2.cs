using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Physics.Colliders
{
    public class ColliderDetector2 : MonoBehaviour
    {
        public GameObject Cube;

        public GameObject Cube2;

        private float CubeFace;

        private Vector3 CubePosition;

        private float CubeFace2;

        private Vector3 CubePostion2;

        void Start()
        {
            CubeFace = Cube.transform.localScale.x;
            CubeFace2 = Cube2.transform.localScale.x;
        }

        void FixedUpdate()
        {
            CubePosition = Cube.transform.position;
            CubePostion2 = Cube2.transform.position;

            float Distance = Vector3.Distance(CubePosition, CubePostion2);

            var newColor = Distance <= (CubeFace + CubeFace2) / 2
                ? new Color(0, 255, 0)
                : new Color(0, 0, 0);

            this.GetComponent<Renderer>().material.color = newColor;
        }
    }
}

