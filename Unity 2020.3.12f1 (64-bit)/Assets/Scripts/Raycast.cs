using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Raycast : MonoBehaviour
{
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;
    public GameObject currentHitObject;
    GameObject TerrainHoles;

    private Vector3 origin;
    private Vector3 direction;
    private float currentHitDistance;

    void Start()
    {
        //GameObject TerrainHoles = GameObject.FindGameObjectWithTag("Holes");
        //CircleHole circleHole = TerrainHoles.GetComponent<CircleHole>();
        
    }
    void Update()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
        
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Did Hit");
            //CircleHole circleHole = TerrainHoles.GetComponent<CircleHole>();
        }
        //else
        //{
        //    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        //    Debug.Log("Did not Hit");
        //}
        
    }

    

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}

