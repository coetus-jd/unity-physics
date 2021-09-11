using System.Collections.Generic;
using System.Linq;
using Physics.Forces;
using UnityEngine;

namespace Physics.Spring
{
    public class DiatomicMoleculeV2 : MonoBehaviour
    {
        /// <summary>
        /// Posição de equilíbrio
        /// </summary>
        public float BalancePosition;

        public float SpringConstant;

        public List<GameObject> Molecules;

        /// <summary>
        /// Controls the direction of each molecule
        /// </summary>
        public int MoleculeDirection;

        private Force FirstMoleculeForce
        {
            get
            {
                return Molecules?.First()?.GetComponent<Force>();
            }
        }

        private Force LastMoleculeForce
        {
            get
            {
                return Molecules?.Last()?.GetComponent<Force>();
            }
        }

        void FixedUpdate()
        {
            float distanceBetweenMolecules = Vector3.Distance(
                FirstMoleculeForce.transform.position,
                LastMoleculeForce.transform.position
            );

            Debug.Log(distanceBetweenMolecules);

            var springForce = SpringConstant * Mathf.Abs(distanceBetweenMolecules - BalancePosition);
            Debug.Log($"Force {springForce}");
            var springForce2 = -springForce;
            
            FirstMoleculeForce.Forces[0] = new Vector3(springForce2, 0, 0);
            LastMoleculeForce.Forces[0] = new Vector3(springForce, 0, 0);
        }
    }
}