using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebounceBomb : MonoBehaviour {

    public GameObject bomb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bomb.GetComponent<CreatExplore>().canBounce = true;

            Destroy(gameObject);
        }
    }
}
