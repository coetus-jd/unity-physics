using System.Collections.Generic;
using System.Linq;
using Physics.Forces;
using UnityEngine;

namespace Physics.Spring
{
    public class DiatomicMoleculeV3 : MonoBehaviour
    {   
        [SerializeField]
        private GameObject connectMolecule;

        [SerializeField]
        private Vector3 forceHook1;

        [SerializeField]
        private Vector3 forceHook2;

        [SerializeField]
        private Vector3 acceleration1;

        [SerializeField]
        private Vector3 acceleration2;

        [SerializeField]
        private Vector3 velocity1;

        [SerializeField]
        private Vector3 velocity2;

        [SerializeField]
        private float mass1;

        [SerializeField]
        private float mass2;

        [SerializeField]
        private float spring1;

        [SerializeField]
        private float balancePosition;

        void FixedUpdate()
        {
            forceHook1 = spring1 * new Vector3(
                Mathf.Abs(transform.position.x - connectMolecule.transform.position.x) - balancePosition,
                0,
                0
            );

            forceHook2 = -forceHook1;

            acceleration1 = forceHook1 / mass1;
            acceleration2 = forceHook2 / mass2;

            UpdateVelocity();

            transform.position += velocity1 * Time.deltaTime;
            connectMolecule.transform.position += velocity2 * Time.deltaTime;
        }

        void UpdateVelocity()
        {
            velocity1 += acceleration1 * Time.deltaTime;
            velocity2 += acceleration2 * Time.deltaTime;
        }
    }
}