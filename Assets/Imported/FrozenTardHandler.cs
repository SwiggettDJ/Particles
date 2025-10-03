using UnityEngine;

namespace Imported
{
    public class FrozenTardHandler : MonoBehaviour
    {
        private bool physicsOn;
        private void OnTriggerEnter(Collider other)
        {
            if (!physicsOn)
            {
                EnablePhysics();
                physicsOn = true;
            }
        }

        private void EnablePhysics()
        {
            Rigidbody[] rigidbodys = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody body in rigidbodys)
            {
                body.useGravity = true;
            }

            BoxCollider[] colliders = GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider collider in colliders)
            {
                collider.enabled = true;
            }
        }
    }
}
