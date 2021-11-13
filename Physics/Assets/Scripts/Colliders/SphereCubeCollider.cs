using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCubeCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject Sphere;

    private float SphereRadius, SphereTestX, SphereTestY, SphereTestZ;
    [SerializeField]
    private GameObject Cube;

    private float CubeX, CubeY, CubeZ;

    private Vector3 SpherePosition, CubePosition;

    private bool DistanceConfirm;

    private float distance;

    // Start is called before the first frame update
       void Start()
        {
            CubeX = Cube.transform.localScale.x/2;
            CubeY = Cube.transform.localScale.y/2;
            CubeZ = Cube.transform.localScale.z/2;
            SphereRadius = Sphere.transform.localScale.x / 2;

        }

        void FixedUpdate()
        {
            
            CubePosition = Cube.transform.position;
            SpherePosition = Sphere.transform.position;
            
            testSphere();
            cubeRoot();

            if(distance <= SphereRadius)
            {
                DistanceConfirm = true;
            }
            else
            {
                DistanceConfirm = false;
            }

            var newColor = DistanceConfirm
                ? new Color(0, 255, 0)
                : new Color(0, 0, 0);

            GetComponent<Renderer>().material.color = newColor;
        }

        void testSphere()
        {
            if (SpherePosition.x < CubePosition.x)  //Está a esquerda
            {
                SphereTestX = CubePosition.x - CubeX; //Lateral esquerda
            }
            else if (SpherePosition.x > CubePosition.x) //Está a direita
            {
                SphereTestX = CubePosition.x + CubeX; //Lateral direita
            }
            
            if (SpherePosition.y < CubePosition.y)  //Está abaixo
            {
                SphereTestY = CubePosition.y - CubeY; //Lateral Superior
            }
            else if (SpherePosition.y > CubePosition.y) //Está acima
            {
                SphereTestY = CubePosition.y + CubeY; //Lateral inferior
            }

            if (SpherePosition.z < CubePosition.z) //Está atrás
            {
                SphereTestZ = CubePosition.z - CubeZ; //atrás
            }
            else if (SpherePosition.z > CubePosition.z) //Está na frente
            {
                SphereTestZ = CubePosition.z + CubeZ; //frente
            }
        }

        void cubeRoot()
        {

            float distanceX = SpherePosition.x - SphereTestX;
            float distanceY = SpherePosition.y - SphereTestY;
            float distanceZ = SpherePosition.z - SphereTestZ;
            float totalDistance = (distanceX*distanceX*distanceX) + (distanceY*distanceY*distanceY) + ((distanceZ*distanceZ*distanceZ));

            distance = Mathf.Pow(Mathf.Abs(totalDistance), 1f / 3f);
            Debug.Log(distance);
            

        }

}
