using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CircleHole : MonoBehaviour
{
    [SerializeField]
     Terrain t;

    //holes
    public int holeWidth;
    public int holeHeight;
    public int xPos;
    public int zPos;
    private int offSetX;
    private bool[,] holes;
    private int offSetZ;

    //ray
    public Vector3 origin;
    private Vector3 direction = Vector3.down;
    private float currentHitDistance;
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;
    //spawn
    public Transform[] spawnLocations;
    public GameObject[] spawnPrefab;
    public GameObject[] spawnClone;
    void Start()
    {
         offSetZ = holeWidth / 2;
         offSetX = holeHeight / 2;

         holes = new bool[holeWidth, holeHeight];

         SetupTerrainHoles(false);
    }
    private void Update()
    {
        var hasWalls = Physics.SphereCast(new Ray(origin, direction), sphereRadius, maxDistance, layerMask);
        Debug.Log(hasWalls);

    }
    void SetupTerrainHoles(bool deleteHoles)
    {
        Debug.Log("creatingHoles");
        RaycastHit hit;
        //var hasWalls = Physics.CheckSphere(origin, sphereRadius, layerMask);
        var hasWalls = Physics.SphereCast(new Ray(origin,direction), sphereRadius, maxDistance, layerMask);
        
        //var hasWalls = Physics.Raycast(origin, direction, out hit, maxDistance, layerMask);

        Debug.Log(hasWalls);
        if (!hasWalls)
        {

            Vector2 originOfCircle = new Vector2(offSetX, offSetZ);
            for (var x = 0; x < holeWidth; x++)
            {
                for (var y = 0; y < holeWidth; y++)
                {
                    holes[x, y] = deleteHoles || Vector2.Distance(new Vector2(x, y), originOfCircle) > offSetX;

                }
            }

            t.terrainData.SetHoles(xPos - offSetX, zPos - offSetZ, holes);
        }
        
    }
    void OnApplicationQuit()
    {
        SetupTerrainHoles(true);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        var spheres = maxDistance / (sphereRadius * 2); 
        for(var i = 0f; i<maxDistance; i += sphereRadius * 2)
        {
            Gizmos.DrawWireSphere(origin + direction * i, sphereRadius);

        }
    }
}
