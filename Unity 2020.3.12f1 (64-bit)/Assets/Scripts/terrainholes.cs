using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainholes : MonoBehaviour
{
    public Texture texture;
    [SerializeField] private Terrain terrain;
    void Start()
    {
        var b = new bool[175 , 0];
        for (var x = 0; x < 100; x++)
            for (var y = 0; y < 100; y++)
                b[x, y] = !(x > 20 && x < 80 && y > 20 && y < 80);
        terrain.terrainData.SetHoles(0, 0, b);

    }
    public void SyncTexture(string texture)
    {
        
    }
}
