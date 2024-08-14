using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


public class AimControl : MonoBehaviour
{
    [SerializeField] private AimConstraint chestAim;
    [SerializeField] private Transform aimRig;
    [SerializeField] private Suavizar LookVector;
public void Aim(InputAction ctx
    )  
    {
        bool val = ctx.ReadValueAsButton();
        chestAim.enabled = val;
        aimRig.gameObject.SetActive(val);
    }

    public void Look(InputAction.CallbackContext ctx)
    {
        LookVector.TargetValue = ctx.ReadValue<Vector2>();
    }


    private void Update()
    {
        LookVector.update();
        aimRig.RotateAround(aimRig.position, transform.up, LookVector.CurrentValue.x);
    }
    private void Awake()
    {
        aimRig.gameObject.SetActive(false);
    }

}

