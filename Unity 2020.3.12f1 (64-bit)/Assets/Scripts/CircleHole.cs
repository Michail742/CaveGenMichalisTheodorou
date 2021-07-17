using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CircleHole : MonoBehaviour
{
    [SerializeField]
     Terrain t;

    public int holeWidth;
    public int holeHeight;
    public int xPos;
    public int zPos;
    private int offSetX;
    private bool[,] holes;
    private int offSetZ;

    void Start()
    {
         offSetZ = holeWidth / 2;
         offSetX = holeHeight / 2;

         holes = new bool[holeWidth, holeHeight];

         SetupTerrainHoles(false);
    }
    void SetupTerrainHoles(bool deleteHoles)
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
    void OnApplicationQuit()
    {
        SetupTerrainHoles(true);
    }
}
