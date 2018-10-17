using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatProp : MonoBehaviour {

    public GameObject[] prop;
    private Quaternion quaternion;
    private Vector3 pos;
    private int randomEnable;


    private void Awake()
    {
        randomEnable = Random.Range(0,6);
    }
    // Use this for initialization
    void Start () {
        
        pos =transform.position;
        quaternion = Quaternion.Euler(0,0,0);
        if (randomEnable %2 ==0)
        {
            enabled = true;
        }
        else
        {
            enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnDisable()
    {

        if (enabled == true)
        {
   
            int i = Random.Range(0, 3);
            Instantiate(prop[i], pos, quaternion);
        }
         else
             return;
    }
}
