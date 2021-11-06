using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Physics.Colliders
{
    public class CubeColliderDetector : MonoBehaviour
    {
        public GameObject Cube;

        public GameObject Cube2;

        private float CubeX;
        private float CubeY;
        private float CubeZ;

        private Vector3 CubePosition;

        private float CubeX2;
        private float CubeY2;
        private float CubeZ2;

        private Vector3 CubePosition2;

        private bool DistanceConfirm;

        void Start()
        {
            CubeX = Cube.transform.localScale.x;
            CubeY = Cube.transform.localScale.y;
            CubeZ = Cube.transform.localScale.z;
            CubeX2 = Cube2.transform.localScale.x;
            CubeY2 = Cube2.transform.localScale.y;
            CubeZ2 = Cube2.transform.localScale.z;
        }

        void FixedUpdate()
        {
            CubePosition = Cube.transform.position;
            CubePosition2 = Cube2.transform.position;

            float distanceX = Mathf.Abs(CubePosition.x - CubePosition2.x);
            float distanceY = Mathf.Abs(CubePosition.y - CubePosition2.y);
            float distanceZ = Mathf.Abs(CubePosition.z - CubePosition2.z);

            if (
                distanceX <= (CubeX + CubeX2) / 2
                && distanceY <= (CubeY + CubeY2) / 2
                && distanceZ <= (CubeZ + CubeZ2) / 2
            )
                DistanceConfirm = true;
            else
                DistanceConfirm = false;

            var newColor = DistanceConfirm
                ? new Color(0, 255, 0)
                : new Color(0, 0, 0);

            GetComponent<Renderer>().material.color = newColor;
        }
    }
}

