using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using callbackcontext = UnityEngine.InputSystem.InputAction.CallbackContext;


public class Movimiento : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private Suavizar motionVector = new Suavizar (true);


    private int velocityxid;
    private int velyid;
    public void movimiento(callbackcontext ctx)
    {
        Vector2 direction = ctx.ReadValue<Vector2>();
        motionVector.TargetValue = direction;
       
    }
    public void ToggleSprint(callbackcontext ctx)
    {
        bool val = ctx.ReadValueAsButton();
        motionVector.Clamp = !val;
    }
        

    private void Awake()
    {
        velocityxid = Animator.StringToHash("velocity x");
        velyid = Animator.StringToHash("vely");
    }
    private void Update()
    {
        motionVector.update();
        Vector2 direction = motionVector.CurrentValue;
        anim.SetFloat("velocity x", direction.x);
        anim.SetFloat("vel y", direction.y);
    }
    private void OnAnimatorMove()
    {
        anim.ApplyBuiltinRootMotion();
        float interpolator =Mathf.Abs( Vector3.Dot(CameraTransform.forward, transform.up)); 

        Vector3 forward = Vector3.Lerp(CameraTransform.forward,CameraTransform.up, interpolator);
        Vector3 projected = Vector3.ProjectOnPlane(forward, transform.up);
        Quaternion rotation = quaternion.LookRotation(projected, transform.up);
        anim.rootRotation = Quaternion.Slerp(anim.rootRotation,  rotation, motionVector.CurrentValue.magnitude);
        anim.ApplyBuiltinRootMotion();
    }

}




  