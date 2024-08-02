using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using callbackcontext = UnityEngine.InputSystem.InputAction.CallbackContext;


public class Movimiento : MonoBehaviour
{
    [SerializeField] private Animator anim;
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


}




  