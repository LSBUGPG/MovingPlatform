using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1.0f;
    new public Rigidbody rigidbody;

    void Update()
    {
        rigidbody.MoveRotation(Quaternion.Euler(0.0f, Time.time * speed, 0.0f));
    }
}
