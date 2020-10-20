using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager> {
    public float AimDepth;
    Camera _camera;
    public Camera Camera
    {
        get
        {
            if(_camera == null)
            {
                _camera = GetComponent<Camera>();
                if (_camera == null)
                    Debug.LogError("I have no camera!");             
            }
            return _camera;
        }
    }

    public Vector3 ScreenToWorldPoint(Vector3 screenPosition)
    {
        return Camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, AimDepth));
    }
}
