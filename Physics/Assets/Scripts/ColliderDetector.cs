using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        float Distance = Vector3.Distance(SpherePosition,SpherePostion2);

        Debug.Log(Distance);


        if (Distance <= (SphereCollider + SphereCollider2)/2)
        {
            this.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }

        else
        {
            this.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        }



    }
}
