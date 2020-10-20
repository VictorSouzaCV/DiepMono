using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager> {
    public float AimDepth;
    Camera camera;
    public Camera Camera
    {
        get
        {
            if(camera == null)
            {
                camera = GetComponent<Camera>();
                if (camera == null)
                    Debug.LogError("I have no camera!");             
            }
            return camera;
        }
    }

    public Vector3 ScreenToWorldPoint(Vector3 screenPosition)
    {
        return Camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, AimDepth));
    }
}
