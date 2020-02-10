using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class OrbitTwo : MonoBehaviour
{
    public GameObject planet;

    void Update()
    {
        transform.RotateAround(planet.transform.position, new Vector3(0f, 1f, 0f), 12f * Time.deltaTime);
    }

   
}
