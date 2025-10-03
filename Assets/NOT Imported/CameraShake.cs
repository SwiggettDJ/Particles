using System.Collections;
using Cinemachine;
using UnityEngine;

namespace NOT_Imported
{
    public class CameraShake : MonoBehaviour
    {
        private CinemachineImpulseSource impulse;

        [SerializeField] private float preDelay;
        [SerializeField] private float postDelay;
        // Start is called before the first frame update
        void Start()
        {
            impulse = GetComponent<CinemachineImpulseSource>();
            StartCoroutine(Shake());
        }

        private IEnumerator Shake()
        {
            yield return new WaitForSeconds(preDelay);
            impulse.GenerateImpulse();
            yield return new WaitForSeconds(postDelay);
            StartCoroutine(Shake());
        }
    }
}
