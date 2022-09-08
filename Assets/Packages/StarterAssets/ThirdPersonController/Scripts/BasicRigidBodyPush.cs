﻿using StarterAssets;
using UnityEngine;

public class BasicRigidBodyPush : MonoBehaviour
{
    public LayerMask pushLayers;
    public bool canPush;
    public float strength;
    public float kickCoefficient;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (canPush) PushRigidBodies(hit);
    }

    private void PushRigidBodies(ControllerColliderHit hit)
    {
        // https://docs.unity3d.com/ScriptReference/CharacterController.OnControllerColliderHit.html

        // make sure we hit a non kinematic rigidbody
         Rigidbody body = hit.collider.attachedRigidbody;
            if (body == null || body.isKinematic) return;

            // make sure we only push desired layer(s)
            var bodyLayerMask = 1 << body.gameObject.layer;
            if ((bodyLayerMask & pushLayers.value) == 0) return;

            // We dont want to push objects below us
            if (hit.moveDirection.y < -0.3f) return;

            // Calculate push direction from move direction, horizontal motion only
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.2f, hit.moveDirection.z);

        // Apply the push and take strength into account
        if (!ThirdPersonController.Instance.Grounded)
        {
            body.AddForce(pushDir * strength * kickCoefficient, ForceMode.Impulse);
        }
        else
        {
            body.AddForce(pushDir * strength, ForceMode.Impulse);
        }
    }
}