using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    //public float height = 5.0f;
    //public float distance = 10.0f;
    public float rotationDamping;
    //public float heightDamping;
    public float smoothTime = 0.3F;
    public Vector3 shift = new Vector3(0, 5, -10);
    
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition = Vector3.zero;



    private void LateUpdate()
    {
        if (!target)
        {
            return;
        }

        // var wantedRotationAngle = target.eulerAngles.y;
        // var wantedHeight = target.position.y + height;
        //
        // var currentRotationAngle = transform.eulerAngles.y;
        // var currentHeight = transform.position.y;
        //
        // currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        // currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        //
        // var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        //
        // transform.position = target.position;
        // transform.position -= currentRotation * Vector3.forward * distance;
        //
        // transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        targetPosition = target.TransformPoint(shift);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping * Time.deltaTime);
    }
}