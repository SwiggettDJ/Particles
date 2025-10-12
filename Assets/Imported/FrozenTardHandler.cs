using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Imported
{
    public class FrozenTardHandler : MonoBehaviour
    {
        private Vector3 forcepoint;
        private bool physicsOn;
        private float horizontalForce;
        private float verticalForce = 2f;
        

        private void OnTriggerEnter(Collider other)
        {
            if (!physicsOn && other.gameObject.layer != LayerMask.NameToLayer("Tard"))
            {
                physicsOn = true;
                forcepoint = other.transform.position;
                if (other.GetComponent<zoomfast>())
                {
                    horizontalForce = other.GetComponent<zoomfast>().speed;
                }
                EnablePhysics();
            }
        }

        private void EnablePhysics()
        {
            MeshCollider[] colliders = GetComponentsInChildren<MeshCollider>();
            foreach (MeshCollider collider in colliders)
            {
                collider.enabled = true;
            }
            
            Rigidbody[] rigidbodys = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody body in rigidbodys)
            {
                body.useGravity = true;
                //horizontalForce = Random.Range(horizontalForce*0.8f, horizontalForce);
                //body.AddRelativeForce(new Vector3(-horizontalForce,verticalForce,0) , ForceMode.Impulse);
                
            }
            
        }
    }
}
