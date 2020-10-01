using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float mouseSensitivity = 8;
    public Transform target;
    public float dstFromTarget = 4;
    public float adjustedDistance = 4;
    public Vector2 pitchMinMax = new Vector2(-20, 40);

    public float rotationSmoothTime = 0.12f;
    public float smoothFollow = 0.05f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;
    Vector3 destination = Vector3.zero;
    Vector3 adjustedDestination = Vector3.zero;
    float yaw;
    float pitch;

    public CameraCollision collision;
    private bool oldColliding;
    private float collisionDistance;

    private void Start()
    {
        collision.Initalize(Camera.main);

        collision.UpdateCameraClipPoints(transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
        collision.UpdateCameraClipPoints(destination, transform.rotation, ref collision.desiredCameraClipPoints);

        InvokeRepeating("setFalse", 1, 3);
    }

    private void FixedUpdate()
    {
        collision.UpdateCameraClipPoints(transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
        collision.UpdateCameraClipPoints(destination, transform.rotation, ref collision.desiredCameraClipPoints);

        collision.CheckColliding(target.position);
        adjustedDistance = collision.GetAdjustedDistanceWithRayFrom(transform.position);
        //collisionDistance = distanceToWall();
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        if (!collision.colliding && oldColliding)
        {
            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
            transform.eulerAngles = currentRotation;
            destination = (target.position - transform.forward * dstFromTarget);
            transform.position = Vector3.Lerp(transform.position, destination , 0.1f);
            transform.LookAt(target);
        }
        else if(!collision.colliding)
        {
            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
            transform.eulerAngles = currentRotation;
            destination = (target.position - transform.forward * dstFromTarget);
            transform.position = destination;
        }
        else
        {
            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
            transform.eulerAngles = currentRotation;
            destination = (target.position - transform.forward * dstFromTarget);
            transform.position = Vector3.Lerp(transform.position, (destination + (new Vector3(0, 6, 1))), 0.1f);
            transform.LookAt(target);
            oldColliding = true;
        }
    }

    public void setFalse()
    {
        oldColliding = false;
    }

    public float distanceToWall()
    {
        float distance = -1;

        Ray ray = new Ray(target.transform.position, Vector3.back);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (distance == -1)
                distance = hit.distance;
            else
            {
                if (hit.distance < distance)
                    distance = hit.distance;
            }
        }
        Debug.Log(distance);
        return distance;
    }
}
