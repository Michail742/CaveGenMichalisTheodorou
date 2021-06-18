using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleHole : MonoBehaviour
{
    [SerializeField]
     Terrain t;

    public bool[,] holes;
    public int holeWidth;
    public int holeHeight;
    public int xPos;
    public int zPos;
    // Start is called before the first frame update
    void Start()
    {
        int offSetZ = holeWidth / 2;
        int offSetX = holeHeight / 2;

        var b = new bool[holeWidth, holeHeight];

        Vector2 originOfCircle = new Vector2(offSetX, offSetZ);
        for (var x = 0; x < holeWidth; x++)
        {
            for (var y = 0; y < holeWidth; y++)
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


        t.terrainData.SetHoles(xPos - offSetX, zPos - offSetZ, b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
