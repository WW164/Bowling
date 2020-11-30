using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public float distance;
    public float height;
    public GameObject objectTofollow;

    private void LateUpdate()
    {

        if (objectTofollow == null)
            return;

        Vector3 destionation = objectTofollow.transform.position;
        destionation.x = 0f;
        destionation.y += height;
        destionation.z += distance;

        transform.position = destionation;
        
    }
}
