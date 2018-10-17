using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoKick : MonoBehaviour {

    public Vector3 dir;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb") && gameObject.GetComponent<PlayerController>().kicking)
        {            
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            dir = (transform.position - collision.gameObject.transform.position).normalized;
            collision.gameObject.GetComponent<CreatExplore>().SetDir(dir);                
            StartCoroutine(Init(collision));
           
        }
    }

    IEnumerator Init(Collision bomb)
    {
        yield return new WaitForSeconds(2);
        bomb.gameObject.GetComponent<Rigidbody>().isKinematic = true;

    }
}
