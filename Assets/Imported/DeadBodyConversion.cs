using UnityEngine;

namespace Imported
{
    public class DeadBodyConversion : MonoBehaviour
    {
        private SkinnedMeshRenderer skinnedRenderer;
        private MeshRenderer[] renderers;
        [SerializeField] private Material waterBurnable, stoneBurnable, fireBurnable;
        [SerializeField] private GameObject stoneGeo;

        public void ConvertBurningBody(Elem element)
        {
            skinnedRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            switch (element)
            {
                case Elem.Water:
                    skinnedRenderer.material = waterBurnable;
                    break;
                case Elem.Fire:
                    skinnedRenderer.material = fireBurnable;
                    break;
                case Elem.Stone:
                    skinnedRenderer.material = stoneBurnable;
                    stoneGeo.gameObject.SetActive(true);
                    break;
            }
        }
        public void ConvertFreezingBody(Elem element)
        {
            renderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                Material[] tempMaterials = new Material[renderer.materials.Length];
                for (int i = 0; i < renderer.materials.Length; i++)
                {
                    if (renderer.materials[i].name == "NormalTardMat (Instance)")
                    {
                        switch (element)
                        {
                            case Elem.Water:
                                tempMaterials[i] = waterBurnable;
                                break;
                            case Elem.Fire:
                                tempMaterials[i] = fireBurnable;
                                break;
                            case Elem.Stone:
                                tempMaterials[i] = stoneBurnable;
                                stoneGeo.gameObject.SetActive(true);
                                break;
                            case Elem.Neutral:
                                tempMaterials[i] = renderer.materials[i];
                                break;
                        }
                    }
                    else
                    {
                        tempMaterials[i] = renderer.materials[i];
                    }
                }
                renderer.materials = tempMaterials;
            }
        }
    }
}
