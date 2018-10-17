using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPropsData : MonoBehaviour
{

    private GameObject[] box;

    private void Awake()
    {
        box = GameObject.FindGameObjectsWithTag("Box");
    }

    // Use this for initialization
    void Start()
    {
        RandomCreat();
    }

    private void RandomCreat()
    {
        int[] index = new int[box.Length * (1/3)];
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = UnityEngine.Random.Range(0,box.Length);
            
            box[index[i]].gameObject.AddComponent<CreatProp>();
        }
        
    }

   

    
}