using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearExplotion : MonoBehaviour {
    /// <summary>
    /// This class is destroy the explore when explore playing over
    /// 
    /// <Author> Wumenghua </Author>
    /// </summary>
    private float destroyTime = 0.8f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyTime);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
