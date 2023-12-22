using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserInterfaceInteraction : MonoBehaviour, IHitInterface
{
    public UnityEvent onHitByLaserBeam; 
    public void HitByLaserBeam()
    {
        onHitByLaserBeam.Invoke();
    }
}
