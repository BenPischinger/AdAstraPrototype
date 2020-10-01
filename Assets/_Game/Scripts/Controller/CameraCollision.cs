using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public LayerMask collisionLayer;
    [HideInInspector]
    public bool colliding = true;
    [HideInInspector]
    public Vector3[] adjustedCameraClipPoints;
    [HideInInspector]
    public Vector3[] desiredCameraClipPoints;

    private Camera cam;

    public void Initalize(Camera camera1)
    {
        cam = camera1;
        adjustedCameraClipPoints = new Vector3[5];
        desiredCameraClipPoints = new Vector3[5];
    }

    public void UpdateCameraClipPoints(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] intoArray)
    {
        if (!cam)
            return;

        //clear the contents
        intoArray = new Vector3[5];

        float z = cam.nearClipPlane;
        float x = Mathf.Tan(cam.fieldOfView / 3.41f) * z;
        float y = x / cam.aspect;

        //top left
        intoArray[0] = (atRotation * new Vector3(-x, y, z)) + cameraPosition;
        //top right
        intoArray[1] = (atRotation * new Vector3(x, y, z)) + cameraPosition;
        //button left
        intoArray[2] = (atRotation * new Vector3(-x, -y, z)) + cameraPosition;
        //button right
        intoArray[3] = (atRotation * new Vector3(x, -y, z)) + cameraPosition;
        //camera position
        intoArray[4] = cameraPosition - cam.transform.forward;
    }

    public bool CollisionDetectedAtClipPoints(Vector3[] clipPoints, Vector3 fromPosition)
    {
        for(int i = 0; i < clipPoints.Length; i++)
        {
            Ray ray = new Ray(fromPosition, clipPoints[i] - fromPosition);
            float distance = Vector3.Distance(clipPoints[i], fromPosition);
            if(Physics.Raycast(ray, distance, collisionLayer))
            {
                return true;
            }
        }
        return false;
    }

    public float GetAdjustedDistanceWithRayFrom(Vector3 from)
    {
        float distance = -1;

        for(int i = 0; i < desiredCameraClipPoints.Length; i++)
        {
            Ray ray = new Ray(from, desiredCameraClipPoints[i] - from);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (distance == -1)
                    distance = hit.distance;
                else
                {
                    if (hit.distance < distance)
                        distance = hit.distance;
                }
            }
        }

        if (distance == -1)
            return 0;
        else
            return distance;
    }

    public void CheckColliding(Vector3 targetPosition)
    {
        if (CollisionDetectedAtClipPoints(desiredCameraClipPoints, targetPosition))
            colliding = true;
        else
            colliding = false;
    }

}