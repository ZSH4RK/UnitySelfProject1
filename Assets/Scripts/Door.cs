using TarodevController;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.Rendering;

public class Door : MonoBehaviour
{
    private PlayerController playercontroller;

    public GameObject MediumDoor;
    public GameObject SmallDoor;
    public bool doorEnabled = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log(playercontroller._currentSizeIndex);
            if (playercontroller._currentSizeIndex == 0)
            {
                doorEnabled = !doorEnabled;
                SmallDoor.GetComponent<BoxCollider2D>().enabled = doorEnabled;
            }

            else if (playercontroller._currentSizeIndex == 1)
            {
                doorEnabled = !doorEnabled;
                SmallDoor.GetComponent<BoxCollider2D>().enabled = doorEnabled;
                MediumDoor.GetComponent<BoxCollider2D>().enabled = doorEnabled;
            }

            else if (playercontroller._currentSizeIndex == 2)
            {
                
                doorEnabled = !doorEnabled;
                SmallDoor.GetComponent<BoxCollider2D>().enabled = doorEnabled;
                MediumDoor.GetComponent<BoxCollider2D>().enabled = doorEnabled;
                GetComponent<Collider2D>().enabled = doorEnabled;


            }
        }
    }
}
