using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatExplore : MonoBehaviour {
    /// <summary>
    ///This class is creat explore when the bomb set active be false
    /// 
    /// <Author> Wumenghua </Author>
    /// </summary>

    public int boomRange;
    private string playerName;

    public GameObject explore;
    public LayerMask LayerMask;
    public bool canBounce = false;
    private float waitToBoom;
    private RaycastHit bombHit;
    private Vector3 direction;//方向

    private bool explode = false;

    BombUp bu = new BombUp();
    // Use this for initialization
    void Start () {
     
        boomRange = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().bombRange;       
        waitToBoom = 3;
        StartCoroutine(Boom(Vector3.forward));
        StartCoroutine(Boom(Vector3.back));
        StartCoroutine(Boom(Vector3.right));
        StartCoroutine(Boom(Vector3.left));
    }


    /// <summary>
    /// This IEnumerator is use to raycast direction
    /// 
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    IEnumerator Boom(Vector3 direction)
    {
       
        yield return new WaitForSeconds(waitToBoom);
        Instantiate(explore, transform.position, transform.rotation);


        //十字爆炸
        for (int i = 1;i< boomRange; i++)
        {
            Physics.Raycast(transform.position+new Vector3(0,0.5f,0), direction, out bombHit, i, LayerMask);            
           
            if (!bombHit.collider)
            {
                Instantiate(explore,transform.position + (i*direction), explore.transform.rotation);

            }
            else
            {
                break;
            }

            
        }
        yield return new WaitForSeconds(0.05f);
        gameObject.SetActive(false);
                
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            waitToBoom = 0;
            StartCoroutine(Boom(Vector3.forward));
            StartCoroutine(Boom(Vector3.back));
            StartCoroutine(Boom(Vector3.right));
            StartCoroutine(Boom(Vector3.left));
        }
    }

    //要被傳入方向
    public void SetDir( Vector3 dir)
    {
        direction = dir;
        gameObject.GetComponent<Rigidbody>().AddForce(-direction * 200);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //亂數成立，才會反彈
        int rand = Random.Range(1,4);
        if ((collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Block")) && rand == 3 /*&& 亂數成立*/)
        {
            
            gameObject.GetComponent<Rigidbody>().AddForce(direction * 200, ForceMode.Force);
        }
        else
            return;
    }

    
    private void OnDisable()
    {
        Destroy(gameObject,4);
    }


}
