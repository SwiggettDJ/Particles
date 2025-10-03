using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

namespace NOT_Imported.Scripts
{
    public class ShieldBehaviour : MonoBehaviour
    {
        private VisualEffect shieldVFX;
        private Animator lightAnimator;
    
        void Start()
        {
            shieldVFX = GetComponent<VisualEffect>();
            lightAnimator = GetComponentInChildren<Animator>();
        }

        public void BreakShield()
        {
            StartCoroutine(Delay(3.5f));
        }

        IEnumerator Delay(float timeBeforeReset)
        {
            shieldVFX.SendEvent("OnBreakStart");
            shieldVFX.SetBool("Kill Ring", true);
        
            float breakDuration = shieldVFX.GetFloat("Break Duration");
            lightAnimator.SetFloat("ExplosionMultiplier", 1/breakDuration);
            lightAnimator.SetTrigger("Explode");
        
            yield return new WaitForSeconds(breakDuration);
        
            shieldVFX.SendEvent("OnBreakEnd");
            shieldVFX.SetBool("Kill Particles", true);
        
            yield return new WaitForSeconds(timeBeforeReset);
        
            Reset();
        }

        private void Reset()
        {
            shieldVFX.SetBool("Kill Particles", false);
            shieldVFX.SetBool("Kill Ring", false);
            shieldVFX.Reinit();
            lightAnimator.Rebind();
        }
    }
}
