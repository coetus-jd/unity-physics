using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        float Distance = Vector3.Distance(CubePosition,CubePostion2);

        Debug.Log(Distance);


        if (Distance <= (CubeFace + CubeFace2)/2)
        {
            this.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }

        else
        {
            this.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        }



    }
}
