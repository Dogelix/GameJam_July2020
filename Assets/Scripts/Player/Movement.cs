using Dogelix.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _speed = 10.0f;
    public float _pushPower = 2.0f;
    public float _weight = 6.0f;

    Vector3 _moveDir;
    CharacterController _characterController;
    public Animator _animator;
    AnimatorController _animatorController;
    BlendTree _blendTree;
    public GameObject _characterModel;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        //_animator = GetComponentInChildren<Animator>();
        _animatorController = GetComponent<AnimatorController>();
    }

    private void Update()
    {
        Move();
        RotateModel();

        //if (_characterController.velocity.sqrMagnitude == 0  )
        //{
        //    _animator.SetFloat("move_x", 0);
        //    _animator.SetFloat("move_y", 0);
        //}
    }

    private void RotateModel()
    {
        if( InputManager._i.GetKey(KeybindingActions.MoveForward) > 0 )
        {
            _characterModel.transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("Moving", true);
        }
        else if( InputManager._i.GetKey(KeybindingActions.MoveForward) < 0 )
        {
            _characterModel.transform.rotation = Quaternion.Euler(0, -180, 0);
            _animator.SetBool("Moving", true);
        }
        else if ( InputManager._i.GetKey(KeybindingActions.MoveRight) > 0 )
        {
            _characterModel.transform.rotation = Quaternion.Euler(0, 90, 0);
            _animator.SetBool("Moving", true);
        }
        else if ( InputManager._i.GetKey(KeybindingActions.MoveRight) < 0 )
        {
            _characterModel.transform.rotation = Quaternion.Euler(0, -90, 0);
            _animator.SetBool("Moving", true);
        }
        else
        {
            _animator.SetBool("Moving", false);
        }
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

    List<Vector3> vector3s = new List<Vector3>();

    private void OnDrawGizmos()
    {
        foreach ( var item in vector3s )
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(item, item + Vector3.up);
        }
    }

    //Pushing blocks
    private void OnControllerColliderHit( ControllerColliderHit hit )
    {
        var body = hit.collider.attachedRigidbody;
        Vector3 force;

        if ( body == null || body.isKinematic )
        {
            return;
        }

        //vector3s.Add(StaticFunctions.GetLocationOfHit(body.gameObject, hit.normal));

        force = hit.controller.velocity * _pushPower;

        //body.

        body.AddForceAtPosition(force, hit.point);
        _animator.SetTrigger("Pushing");
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
