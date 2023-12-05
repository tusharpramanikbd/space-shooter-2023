using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupControl : MonoBehaviour
{
    private void Update()
    {
        //Control the rotation of the canvas
        transform.LookAt(Camera.main.transform);

        //remove after 3 sec
        Destroy(gameObject, 3f);
    }
}
