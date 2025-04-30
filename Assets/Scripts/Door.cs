using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject MediumDoor;
    public GameObject SmallDoor;
    public bool doorEnabled = true;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in scene!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            ToggleDoors();
        }
    }

    private void ToggleDoors()
    {
        if (playerController == null) return;

        Debug.Log("Current Size Index: " + playerController._currentSizeIndex);

        doorEnabled = !doorEnabled;

        // Always toggle small door
        if (SmallDoor != null)
            SmallDoor.GetComponent<BoxCollider2D>().enabled = doorEnabled;

        // Medium and Large toggles depending on size
        if (IsSize(1) || IsSize(2))
        {
            if (MediumDoor != null)
                MediumDoor.GetComponent<BoxCollider2D>().enabled = doorEnabled;
        }

        if (IsSize(2))
        {
            Collider2D largeDoorCollider = GetComponent<Collider2D>();
            if (largeDoorCollider != null)
                largeDoorCollider.enabled = doorEnabled;
        }
    }

    private bool IsSize(int size)
    {
        return playerController._currentSizeIndex == size;
    }
}
