using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothZ = 0.125f;
    [SerializeField] private float smoothX = 0.025f;

    private Vector3 smoothedPositionZ;
    private Vector3 smoothedPositionX;

    private void LateUpdate()
    {
        var newPosition = target.position + offset;
        smoothedPositionX = Vector3.Lerp(transform.position, newPosition, smoothX);

        if (!UIController.instance.Finished)
            smoothedPositionZ = Vector3.Lerp(transform.position, newPosition, smoothZ);

        transform.position = new Vector3(smoothedPositionX.x, smoothedPositionZ.y, smoothedPositionZ.z);
    }
}
