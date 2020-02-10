using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class ShipMove : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }
    void Update()
    {
        transform.Translate(0f, 0f, Time.deltaTime);
    }
}
