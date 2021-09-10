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

        void Start()
        {
            FirstMoleculeForce.Forces ??= new List<Vector3>();
            LastMoleculeForce.Forces ??= new List<Vector3>();
        }

        void FixedUpdate()
        {
            float distanceBetweenMolecules = Vector3.Distance(
                FirstMoleculeForce.transform.position,
                LastMoleculeForce.transform.position
            );

            var springForce = SpringConstant * Mathf.Abs(distanceBetweenMolecules - BalancePosition);

            if (distanceBetweenMolecules < BalancePosition)
                MoleculeDirection = 1;
            else
                MoleculeDirection = -1;

            float movementDirection = springForce * MoleculeDirection;

            if (FirstMoleculeForce.Forces?.Count == 0)
                FirstMoleculeForce.Forces.Add(new Vector3(movementDirection * -1, 0, 0));
            else if (FirstMoleculeForce.GetComponent<Molecule>().IsMiddle && FirstMoleculeForce.Forces?.Count < 2)
                FirstMoleculeForce.Forces.Add(new Vector3(movementDirection * 1, 0, 0));
            else
            {
                FirstMoleculeForce.Forces[0] = new Vector3(movementDirection * -1, 0, 0);

                if (FirstMoleculeForce.GetComponent<Molecule>().IsMiddle)
                    FirstMoleculeForce.Forces[1] = new Vector3(movementDirection * 1, 0, 0);
            }

            if (LastMoleculeForce?.Forces?.Count == 0)
                LastMoleculeForce.Forces.Add(new Vector3(movementDirection * 1, 0, 0));
            else
                LastMoleculeForce.Forces[0] = new Vector3(movementDirection * 1, 0, 0);
        }
    }
}