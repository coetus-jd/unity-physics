using System.Collections;
using System.Collections.Generic;
using Physics.Acceleration;
using UnityEngine;

public class HookesLaw : MonoBehaviour
{
    public float NormalPosition;

    public float SpringConstant;

    public GameObject ConnectedObject;

    /// <summary>
    /// Armazena os valores de todas as forças elásticas nos 3 eixos
    /// </summary>
    [SerializeField]
    private Vector3 SpringForce;
    
    private MovementT2 movement;

    private float Distance;

    private int MovementDirection;

    private bool PassedWall;

    void Start()
    {
        movement = GetComponent<MovementT2>();
    }

    void FixedUpdate()
    {
        Distance = Vector3.Distance(
            ConnectedObject.transform.position,
            transform.position
        );

        if (Distance > NormalPosition)
            MovementDirection = -1;
        else
            MovementDirection = 1;

        SpringForce = ((SpringConstant * transform.position)
            * MovementDirection)
            * Time.deltaTime;

        movement.accleration = SpringForce;
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider);
        if (collider.gameObject.name == "Wall")
            PassedWall = !PassedWall;
    }
}
