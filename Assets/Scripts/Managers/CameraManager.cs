using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{

    public Camera MainCamera;
    public GameObject FollowTarget;
    private float followDistance;
    private float scaleSpeed = 10;
    private float rotateSpeed =  10;

    protected override void Awake()
    {
        MainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton((int)MouseButton.Right))
        {
            var x = Input.GetAxis("Mouse X");
            var y = Input.GetAxis("Mouse Y");
            RotateCamera(x, y);
        }
        var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0) {
            ScaleCamera(scrollWheel);
        }
    }

    private void RotateCamera(float x, float y) {
        if (FollowTarget == null) return;
        MainCamera.transform.RotateAround(FollowTarget.transform.position, Vector3.up, x * rotateSpeed);
        MainCamera.transform.RotateAround(FollowTarget.transform.position, MainCamera.transform.right, -y * rotateSpeed);
    }

    private void ScaleCamera(float scale)
    {
        if (FollowTarget == null) return;
        MainCamera.transform.Translate(Vector3.forward * scaleSpeed * scale, Space.Self);
    }

    private void CheckFollowDistance() {
        followDistance = Mathf.Max(0, followDistance);
        followDistance = Mathf.Min(10, followDistance);
    }

}
