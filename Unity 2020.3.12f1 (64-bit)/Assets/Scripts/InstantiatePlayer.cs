using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{
    
    public Transform player;
    public void Start()
    {
            Instantiate(player, new Vector3(2.0F, -3.5f, 0), Quaternion.identity);
    }

    
}
