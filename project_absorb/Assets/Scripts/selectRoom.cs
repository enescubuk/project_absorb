using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectRoom : MonoBehaviour
{
    public Camera mainCamera;
    public Vector2 detectionBoxSize = new Vector2(0.2f, 0.2f);
    public float rotationAngle = 0;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Collider2D detectedCollider = 
            Physics2D.OverlapBox(mouseWorldPosition, detectionBoxSize, rotationAngle);
    }
}
