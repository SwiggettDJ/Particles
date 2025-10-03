using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.VFX;

namespace Imported
{
    public class TestBurn : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<Animator>(out Animator otherAnim))
            {
                if (otherAnim.runtimeAnimatorController.name == "BurnController")
                {
                    otherAnim.SetTrigger("Burn");
                
                    if (other.TryGetComponent<VisualEffect>(out VisualEffect effect))
                    {
                        effect.enabled = true;
                    }
                }
            }
        
        }
    
    }
}
