using UnityEngine;

namespace Physics.Assets.Scripts
{
    public class AddVelocityToRb : MonoBehaviour
    {
        [SerializeField]
        private float Velocity = 2f;

        void Start()
        {
            GetComponent<Rigidbody>()
                .AddForce(
                    new Vector3(Velocity, 0, 0),
                    ForceMode.Acceleration
                );
        }
    }
}