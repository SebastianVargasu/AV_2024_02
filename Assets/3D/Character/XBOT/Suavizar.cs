using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[SerializeField]
public struct Suavizar
{
    private Vector2 currentValue;
    private Vector2 targetValue;
    private Vector2 velocity;
    [SerializeField] private float smoothTime;
    


    public void update ()
    {
       currentValue = Vector2.SmoothDamp(currentValue, targetValue, ref velocity, smoothTime);

    }
    public Vector2 CurrentValue => currentValue;
    public Vector2 TargetValue { set => targetValue = value; }

}