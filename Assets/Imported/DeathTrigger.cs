using UnityEngine;

namespace Imported
{
    public class DeathTrigger : MonoBehaviour
    {
        public DeathType deathType;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TardigradeBase tardigrade))
            {
                tardigrade.Death(deathType);
            }
        }
    }
}
