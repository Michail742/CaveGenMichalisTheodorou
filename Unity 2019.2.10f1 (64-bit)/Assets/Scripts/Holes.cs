using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Holes : MonoBehaviour
{
    [SerializeField] 
     Terrain terrain;

    public bool[,] holes;
    public int xBase;
    public int yBase;
    public int holeWidth;
    public int holeHeight;
    public int x;
    public int y;
    public int xPos;
    public int zPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetHoles(int xBase, int yBase, bool[,] holes)
    {
        int offSetZ = holeWidth / 2;
        int offSetX = holeHeight / 2;

        var b = new bool[holeWidth, holeHeight];

        Vector2 originOfCircle = new Vector2(offSetX, offSetZ);
        for (xBase = 0; x < holeWidth; x++)
        {
            for (yBase = 0; y < holeWidth; y++)
            {

                if (Vector2.Distance(new Vector2(x, y), originOfCircle) <= offSetX)
                {
                    b[x, y] = false;
                }
                else
                {
                    b[x, y] = true;
                }
            }
        }


        //terrain.terrainData.SetHoles(xPos - offSetX, zPos - offSetZ, b);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
