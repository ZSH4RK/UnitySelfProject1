//using System.Collections;
//using TarodevController;
//using UnityEngine;

//public class Grate : MonoBehaviour
//{
//    private Collider2D grateCollider;
//    private PlayerController playerController;

//    private void Start()
//    {
//        grateCollider = GetComponent<Collider2D>();

//        // If the Grate object has no collider, warn the developer
//        if (grateCollider == null)
//        {
//            Debug.LogError("No Collider found on Grate!");
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerController = other.GetComponent<PlayerController>();
//            if (playerController != null && IsSize(0))
//            {
//                DisableCollider();
//            }
//        }
//    //}

//    private void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            EnableCollider();
//        }
//    }

//    private void OnCollisionStay2D(Collision2D other)
//    {
//        if (other.gameObject.CompareTag("Player"))
//        {
//            playerController = other.gameObject.GetComponent<PlayerController>();
//            if (playerController != null)
//            {
//                playerController.CheckSize();
//            }
//        }
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            EnableCollider();
//        }
//    }

//    private bool IsSize(int size)
//    {
//        return playerController._currentSizeIndex == size;
//    }

//    private void DisableCollider()
//    {
//        if (grateCollider != null)
//        {
//            Debug.Log("Small player entered grate - disabling collider on " + gameObject.name);
//            grateCollider.enabled = false;
//        }
//    }

//    private void EnableCollider()
//    {
//        if (grateCollider != null)
//        {
//            grateCollider.enabled = true;
//        }
//    }
//}
//           FallThroughGrate();
//        }
//    }
//}
