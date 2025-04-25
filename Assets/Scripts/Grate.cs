using System.Collections;
using TarodevController;
using UnityEngine;

public class Grate : MonoBehaviour
{
    private void Update()
    {
        
    }


    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        PlayerController player = other.GetComponent<PlayerController>();
    //        if (player != null && player._currentSizeIndex == 0)
    //        {
    //            Debug.Log("Small player entered grate - disabling collider on " + gameObject.name);
    //            GetComponent<Collider2D>().enabled = false;
    //        }
    //    }
    //}

        private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "Player Controller")
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.CheckSize();
        }
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    GetComponent<Collider2D>().enabled = true;
    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Collider2D>().enabled = true;
    }

}
