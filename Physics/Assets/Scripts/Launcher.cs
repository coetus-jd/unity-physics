using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Physics.Extensions;
using Physics.Colliders;
using Physics.Assets.Scripts.Forces;
using Physics.Forces;

namespace Physics
{
    public class Launcher : MonoBehaviour
    {   
        [SerializeField]
        private GameObject Sun;

        /// <summary>
        /// Planets that can be launched
        /// </summary>
        [SerializeField]
        private List<GameObject> Planets;

        /// <summary>
        /// Start point to launch the planet
        /// </summary>
        [SerializeField]
        private Transform PointToLaunch;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Launch();
        }

        public void Launch()
        {
            var planetToLaunch = Planets.RandomValue();

            var launchedPlanet = Instantiate(
                planetToLaunch,
                PointToLaunch.position,
                Quaternion.identity
            );

            var collider = launchedPlanet.AddComponent<SphereColliderDetector>();

            collider.Sphere = launchedPlanet;
            collider.SphereMass = launchedPlanet.GetComponent<GravitacionalV2>().PlanetMass;

            collider.Sphere2 = Sun;
            collider.SphereMass2 = launchedPlanet.GetComponent<GravitacionalV2>().SunMass;

            collider.IsPerfectElasticCollision = false;
            collider.ChangeColor = false;
        }
    }
}
