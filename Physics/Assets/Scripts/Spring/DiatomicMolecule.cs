using System.Collections.Generic;
using System.Linq;
using Physics.Forces;
using UnityEngine;

namespace Physics.Spring
{
    public class DiatomicMolecule : MonoBehaviour
    {
        /// <summary>
        /// Posição de equilíbrio
        /// </summary>
        public float BalancePosition;

        public float SpringConstant;

        public List<GameObject> Molecules;

        public int MoleculeDirection;

        void FixedUpdate()
        {
            float distanceBetweenMolecules = Vector3.Distance(
                Molecules.First().transform.position,
                Molecules.Last().transform.position
            );

            var springForce = SpringConstant
                * Mathf.Abs(distanceBetweenMolecules - BalancePosition);

            if (distanceBetweenMolecules < BalancePosition)
                MoleculeDirection = 1;
            else
                MoleculeDirection = -1;

            Molecules
                .First()
                .GetComponent<Force>()
                .Force1 = new Vector3(springForce * MoleculeDirection * -1, 0, 0);

            Molecules
                .Last()
                .GetComponent<Force>()
                .Force1 = new Vector3(springForce * MoleculeDirection * 1, 0, 0);
        }
    }
}