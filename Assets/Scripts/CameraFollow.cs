using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smooth = 0.125f;

    private void LateUpdate()
    {
        var newPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, newPosition, smooth);

        transform.position = new Vector3(0, smoothedPosition.y, smoothedPosition.z);
    }
}
