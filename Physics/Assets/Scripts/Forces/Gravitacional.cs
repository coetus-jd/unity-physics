using System.Collections.Generic;
using Physics.Acceleration;
using Physics.Forces;
using UnityEngine;

namespace Physics.Assets.Scripts.Forces
{
    public class Gravitacional : MonoBehaviour
    {
        public GameObject FirstObject;

        public GameObject SecondObject;

        public float GravitacionalConstant;

        void Start()
        {
            FirstObject.GetComponent<Force>().ActingForces ??= new List<Vector3>();
            SecondObject.GetComponent<Force>().ActingForces ??= new List<Vector3>();

            // Initialize the forces list
            FirstObject.GetComponent<Force>().ActingForces.Add(new Vector3(0, 0, 0));
            SecondObject.GetComponent<Force>().ActingForces.Add(new Vector3(0, 0, 0));
        }

        void FixedUpdate()
        {
            var firstPosition = FirstObject.transform.position;
            var secondPosition = SecondObject.transform.position;

            var firstDirection = (secondPosition - firstPosition).normalized;
            var secondDirection = (firstPosition - secondPosition).normalized;

            FirstObject.GetComponent<Force>().ActingForces[0] = GravitacionalForce(firstDirection);
            FirstObject.GetComponent<MovementT2>().Accleration = FirstObject
                .GetComponent<Force>()
                .Acceleration();

            SecondObject.GetComponent<Force>().ActingForces[0] = GravitacionalForce(secondDirection);
            SecondObject.GetComponent<MovementT2>().Accleration = SecondObject
                .GetComponent<Force>()
                .Acceleration();
        }

        public Vector3 GravitacionalForce(Vector3 direction)
        {
            float distance = Vector3.Distance(
                FirstObject.transform.position,
                SecondObject.transform.position
            );

            var firstMass = FirstObject.GetComponent<Force>().Mass;
            var secondMass = SecondObject.GetComponent<Force>().Mass;

            return (
                (GravitacionalConstant * firstMass * secondMass)
                / (distance * distance)
            ) * direction;
        }
    }
}