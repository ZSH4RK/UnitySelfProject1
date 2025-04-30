using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public bool canOpen = false;
    private bool isShowing;

    public Transform Player;
    public GameObject ChestUI;


     
    void Update()
    {
        OpenChest();
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.name == "Player Controller")
        {
            canOpen = true;
            Debug.Log("can open");
        }
    }

    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.name == "Player Controller")
        {
            canOpen = false;
            Debug.Log("cant open");
        }
    }

    private void OpenChest()
    {
        if (canOpen && Input.GetKeyUp(KeyCode.E))
        {
            isShowing = !isShowing;
            ChestUI.SetActive(isShowing);
            if (isShowing)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            
            
        }
    }


}
