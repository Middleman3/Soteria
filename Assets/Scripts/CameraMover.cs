using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public float x, y, z;
    public Transform target;

    // Use this for initialization
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position;
        pos.x += x;
        pos.y += y;
        pos.z += z;

        transform.position = pos;
    }
}