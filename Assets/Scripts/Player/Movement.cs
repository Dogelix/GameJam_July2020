using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _speed = 10.0f;
    public float _pushPower = 2.0f;
    public float _weight = 6.0f;

    Vector3 _moveDir;
    CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 forwardMovement = transform.forward * InputManager._i.GetKey(KeybindingActions.MoveForward);
        Vector3 strafeMovement = transform.right * InputManager._i.GetKey(KeybindingActions.MoveRight);

        if ( InputManager._i.GetKeyDown(KeybindingActions.Sprint) > 0 )
        {
            _moveDir = ( forwardMovement + strafeMovement ).normalized * ( _speed * 2.0f );

        }
        else
        {
            _moveDir = ( forwardMovement + strafeMovement ) * _speed;
        }

        _characterController.Move(_moveDir);
    }

    private void OnControllerColliderHit( ControllerColliderHit hit )
    {
        var body = hit.collider.attachedRigidbody;
        Vector3 force;

        if ( body == null || body.isKinematic ) return;

        force = hit.controller.velocity * _pushPower;

        //body.

        body.AddForceAtPosition(force, hit.point);
    }
}

/*
 var pushPower = 2.0;
 var weight = 6.0;
 
 function OnControllerColliderHit (hit : ControllerColliderHit)
 {
     var body : Rigidbody = hit.collider.attachedRigidbody;
     var force : Vector3;
 
     // no rigidbody
     if (body == null || body.isKinematic) { return; }
 
     // We use gravity and weight to push things down, we use
     // our velocity and push power to push things other directions
     if (hit.moveDirection.y < -0.3) {
         force = Vector3 (0, -0.5, 0) * movement.gravity * weight;
     } else {
         force = hit.controller.velocity * pushPower;
     }
 
     // Apply the push
     body.AddForceAtPosition(force, hit.point);
 }
     
     */
