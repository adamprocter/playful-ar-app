using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class ARPlace : MonoBehaviour
{
    public List<GameObject> models;
    public GameObject       indicator;

    private ARSessionOrigin origin;
    private Pose            placementPose;
    private bool            canPlace;
    private int             counter;

    void Start()
    {
        origin = FindObjectOfType<ARSessionOrigin>();
    }

    void Update()
    {
        UpdatePlane();
        UpdateTargetPosition();

        if(canPlace && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    private void UpdatePlane()
    {
        Vector3 center = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        origin.GetComponent<ARRaycastManager>().Raycast(center, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneEstimated);

        canPlace = hits.Count > 0;

        if (canPlace)
        {
            placementPose = hits[0].pose;
        }
    }

    private void UpdateTargetPosition()
    {
        if (canPlace)
        {
            indicator.SetActive(true);
            indicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            indicator.SetActive(false);
        }
    }

    private void PlaceObject()
    {
        Instantiate(models[counter], placementPose.position, Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f));
        counter++;
        counter = counter % models.Count;
    }
}
