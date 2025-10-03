using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Imported
{
    public class DecalBehaviours : MonoBehaviour
    {
        //Randomly rotates decal
        protected void RandomRotation(DecalProjector decal)
        {
            float randRot = Random.Range(1, 360);
            decal.transform.Rotate(Vector3.forward, randRot);
        }
    }
}
