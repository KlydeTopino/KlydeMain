using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 _CameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    
    void Start()
    {
        _CameraOffset = transform.transform.position - PlayerTransform.position;
    }

    void Update()
    {
        Vector3 NewPos = PlayerTransform.position + _CameraOffset;

        transform.position = Vector3.Slerp(transform.position, NewPos, SmoothFactor);
    }
}

