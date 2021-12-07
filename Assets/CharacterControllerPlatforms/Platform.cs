using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform start;
    public Transform end;
    new public Rigidbody rigidbody;
    public float speed = 1.0f;

    void Update()
    {
        float time = Mathf.Sin(Time.time * speed) * 0.5f + 0.5f;
        Vector3 position = Vector3.Lerp(start.position, end.position, time);
        rigidbody.MovePosition(position);
    }
}
