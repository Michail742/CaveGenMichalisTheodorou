using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour
{
    public int xPos;
    public int zPos;

    bool[] holes = new bool[7];

    public Arrays(int xPos, int zPos, bool[] holes)
    {
        this.xPos = xPos;
        this.zPos = zPos;
        this.holes = holes;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
