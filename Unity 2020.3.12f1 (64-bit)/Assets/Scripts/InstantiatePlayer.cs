using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{
    
    public Transform prefab;
    public void Start()
    {
       
        for (int i = 0; i < 1; i++)
        {
            Instantiate(prefab, new Vector3(i * 2.0F, 8f, 0), Quaternion.identity);
        }
    }

    
}
