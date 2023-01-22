using UnityEngine;
using UnityEngine.UI;

namespace ToastClient.Modules
{
    public class ThirdPerson : BaseModule
    {
        public static Camera thirdPersonCamera;
        public static GameObject dosomethinga;
        public static Camera vrcCamera;
        public static void InitTPerson()
        {
            vrcCamera = GameObject.Find("Camera (eye)")?.GetComponent<Camera>();
            var originalCameraTransform = vrcCamera.transform;
            thirdPersonCamera = new GameObject("ThirdPerson Camera").AddComponent<Camera>();
            thirdPersonCamera.fieldOfView = 80;
            thirdPersonCamera.nearClipPlane = 0.01f;
            thirdPersonCamera.enabled = true;
            thirdPersonCamera.transform.position = originalCameraTransform.position;
            thirdPersonCamera.transform.rotation = originalCameraTransform.rotation;
        }
        public static void DisableTPerson()
        {
            var balls = GameObject.Find("ThirdPerson Camera");
            GameObject.DestroyImmediate(balls, true);
        }
    }
}