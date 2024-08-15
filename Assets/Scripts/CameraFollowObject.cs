using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    public GameObject parent;

    public Vector3 offSetPos = new Vector3(0,5,-7);
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = parent.transform.position + offSetPos;
    }
}
