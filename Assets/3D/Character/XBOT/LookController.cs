using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LookController : MonoBehaviour
{
    [SerializeField] private Suavizar LookVector;
    [SerializeField] private float sensitivity;
}


{

}
    
        
    

    
    void Update()
    {
        private void Update()
        {
            LookVector.update();
            aimRig.RotateAround(aimRig.position, transform.up, LookVector.CurrentValue.x);
        }
    }
}
