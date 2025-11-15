using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GardenPlacementManager : MonoBehaviour
{
    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject[] plantPrefabs;

    private readonly List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var touch = Input.GetTouch(0);

            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                // pick a random plant prefab
                GameObject randomPlant = plantPrefabs[Random.Range(0, plantPrefabs.Length)];

                Instantiate(randomPlant, hitPose.position, hitPose.rotation);
            }
        }
    }
}
