using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUp : MonoBehaviour {
    public GameObject bomb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)//other指的是碰撞點
    {
        
        
        if (other.CompareTag("Player"))//玩家與道具碰撞檢測
        {
                           
            other.gameObject.GetComponent<PlayerController>().bombRange = 6;
            Destroy(gameObject);   //道具從場景消失  
        }
    }
}
