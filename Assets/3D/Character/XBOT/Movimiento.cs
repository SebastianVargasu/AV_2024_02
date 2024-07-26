using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Vector3 motionDebug;


    private int velocityxid;
        private int velyid;

 #if UNITY_EDITOR
   private void OnValidate()
 {
        movimiento(motionDebug);
    }
#endif

    private void Awake()
    {
       velocityxid = Animator.StringToHash( "velocity x");
        velyid = Animator.StringToHash( "vely");
    }

  
    void Update()
    {
        
    }
    public void movimiento(Vector3 motionDirection)
    {
        anim.SetFloat("velocity x", motionDirection.x);
        anim.SetFloat("vel y", motionDirection.x);
    }
}
