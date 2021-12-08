using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerPlatforms : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 3.0f;
    public float rotateSpeed = 3.0f;
    public float jump = 3.0f;
    Collider platform;
    Vector3 localPoint;
    Vector3 velocity;

    Vector3 SurfacePoint(Collider collider)
    {
        Vector3 surfacePoint = collider.ClosestPoint(transform.position);
        return platform.transform.InverseTransformPoint(surfacePoint);
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        // Move character with platform
        if (characterController.isGrounded && platform != null)
        {
            Vector3 newPoint = platform.transform.TransformPoint(localPoint);
            move = newPoint + Vector3.up * (characterController.height - characterController.skinWidth) * 0.5f - transform.position;
        }

        // Handle jump
        if (characterController.isGrounded)
        {
            if (velocity.y < 0.0f)
            {
                velocity.y = 0.0f;
            }
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y += jump;
            }
        }
        else
        {
            velocity += Physics.gravity * Time.deltaTime;
        }

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        move += (forward * curSpeed + velocity) * Time.deltaTime;
        characterController.Move(move);
        if (characterController.isGrounded)
        {
            if (platform != null)
            {
                localPoint = SurfacePoint(platform);
            }
        }
        else
        {
            platform = null;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit controllerColliderHit)
    {
        if (controllerColliderHit.collider.CompareTag("Platform"))
        {
            platform = controllerColliderHit.collider;
            localPoint = SurfacePoint(platform);
        }
    }
}
