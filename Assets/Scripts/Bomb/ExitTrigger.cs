using UnityEngine;

public class ExitTrigger : MonoBehaviour {
    /// <summary>
    ///When the player exit the bomb then trigger be set false
    ///So the player can not cross the bomb
    /// <Author> Wumenghua </Author>
    /// </summary>
    /// 

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
        }

        
    }


}
