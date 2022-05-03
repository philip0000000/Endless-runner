using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGameobject : MonoBehaviour
{
    public float scrollSpeed = 5.0f;

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;
    }
}
