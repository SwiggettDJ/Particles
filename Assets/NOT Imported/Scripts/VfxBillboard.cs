using UnityEngine;
using UnityEngine.SceneManagement;

namespace NOT_Imported.Scripts
{
    public class VfxBillboard : MonoBehaviour
    {
        private Camera mainCam;
        private void Awake()
        {
            GetSceneMainCamera(SceneManager.GetActiveScene(),SceneManager.GetActiveScene());

            //SceneManager.activeSceneChanged += GetSceneMainCamera;
        }

        private void FaceCamera()
        {
            if (mainCam)
            {
                transform.rotation = Quaternion.Euler(mainCam.transform.rotation.eulerAngles);
            }
        }
        // Update is called once per frame
        void Update()
        {
            FaceCamera();
        }
    
        private void GetSceneMainCamera(Scene arg0, Scene arg1)
        {
            if (Camera.main != null)
            {
                mainCam = Camera.main;
            }
            else
            {
                print(this.name + " could not find main camera");
            }
        }

        private void OnDestroy()
        {
            //SceneManager.activeSceneChanged -= GetSceneMainCamera;
        }
    }
}
