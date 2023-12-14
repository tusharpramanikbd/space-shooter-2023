using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserInterfaceInteraction : MonoBehaviour, IRayCastInterface
{
    public UnityEvent onHitByRayCast; 
    public void HitBtRayCast()
    {
        onHitByRayCast.Invoke();
    }
}
