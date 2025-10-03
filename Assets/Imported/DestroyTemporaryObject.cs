using UnityEngine;

namespace Imported
{
    public class DestroyTemporaryObject : MonoBehaviour
    {
        public float lifespan = 1f;

        public bool isRandom;

        public float range;
        // Start is called before the first frame update
        void Start()
        {
            if (isRandom)
            {
                Destroy(gameObject, Random.Range(lifespan - range/2, lifespan + range/2));
            }
            else
            {
                Destroy(gameObject, lifespan);
            }
        }
    }
}
