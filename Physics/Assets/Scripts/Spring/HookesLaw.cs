using System.Collections;
using System.Collections.Generic;
using Physics.Acceleration;
using UnityEngine;

namespace Physics.Spring
{
    public class HookesLaw : MonoBehaviour
    {
        /// <summary>
        /// Posição de equilíbrio
        /// </summary>
        public Vector3 BalancePosition;

        public float SpringConstant;

        public GameObject ConnectedObject;

        public float DampingConstant;

        /// <summary>
        /// Armazena os valores de todas as forças elásticas nos 3 eixos
        /// </summary>
        [SerializeField]
        private Vector3 SpringForce;

        private MovementT2 movement;

        [SerializeField]
        private bool UseDamping;

        void Start()
        {
            movement = GetComponent<MovementT2>();
        }

        void FixedUpdate()
        {
            CalculateSpringForce();
            movement.accleration = SpringForce;
        }

        /// <summary>
        /// F = K . X
        /// F = -k . (x - x0)
        /// </summary>
        private void CalculateSpringForce()
        {
            if (UseDamping)
            {
                SpringForce = -(DampingConstant * movement.velocity) - (SpringConstant * (transform.position - BalancePosition));
                return;
            }

            SpringForce = -SpringConstant * (transform.position - BalancePosition);
        }
    }
}