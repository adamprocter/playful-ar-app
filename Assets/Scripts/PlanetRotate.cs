using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class PlanetRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, Time.deltaTime * 6, 0f, Space.Self);
    }

}
