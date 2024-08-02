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
    [SerializeField] private float clampMagnitude;
    [SerializeField] private bool clamp;
    
  

    public void update()
    {
        currentValue = Vector2.SmoothDamp(currentValue, 
            target:clamp ? Vector2.ClampMagnitude ( targetValue, clampMagnitude) : targetValue, 
            ref velocity, smoothTime);

    }
    public Vector2 CurrentValue => currentValue;
    public Vector2 TargetValue { set => targetValue = value; }
    public bool Clamp { set => clamp = value; }
}