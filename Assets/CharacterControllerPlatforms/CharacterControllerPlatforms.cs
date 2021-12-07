using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerPlatforms : MonoBehaviour
{
    public CharacterController characterController;
    Collider platform;
    Vector3 hitPoint;
    Vector3 localPoint;

    private void Update()
    {
        Vector3 move = Vector3.zero;
        Debug.Log(platform);
        if (platform != null)
        {
            Vector3 newPoint = transform.TransformPoint(localPoint);
            move = characterController.transform.InverseTransformDirection(newPoint - hitPoint);
            Debug.Log(move);
        }
        platform = null;
        characterController.SimpleMove(move);
    }

    void OnControllerColliderHit(ControllerColliderHit controllerColliderHit)
    {
        if (controllerColliderHit.collider.CompareTag("Platform"))
        {
            platform = controllerColliderHit.collider;
            Debug.Log(platform);
            hitPoint = controllerColliderHit.point;
            localPoint = transform.InverseTransformPoint(hitPoint);
        }
    }
}
