using NUnit.Framework.Constraints;
using System.Collections.Generic;
using TarodevController;
using TMPro;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    private CapsuleCollider2D _col;
    private PlayerController playerController;
    public PlatformDetector platformDetector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        _col = GetComponent<CapsuleCollider2D>();


        platformDetector = GetComponent<PlatformDetector>(); // or assign via Inspector

        if (playerController != null)
        {
            int sizeIndex = playerController.GetCurrentSize();
            Debug.Log("Current Size Index: " + sizeIndex);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {

            Burrow();
            BreakObject();
        }
    }

    void Burrow()
    {
        Debug.Log("Triggered");

        if (!IsSize(0)) return;

        // Get all platforms below using multiple raycasts
        List<GameObject> platforms = platformDetector.DetectPlatforms(Vector2.down);

        foreach (GameObject platform in platforms)
        {
            if (platform != null && platform.CompareTag("Burrowable"))
            {
                Debug.Log("Can Burrow");

                float platformHeight = platform.transform.localScale.y;
                Vector3 pos = playerController.transform.position;
                float platformTop = platform.transform.position.y + (platformHeight / 2f);
                float playerHeight = playerController.transform.localScale.y;
                pos.y = platformTop - platformHeight - playerHeight;
                playerController.transform.position = pos;

                break; // Stop after first valid burrowable platform
            }
        }
    }

    void BreakObject()
    {
        Debug.Log("Breaking");

        if (!IsSize(2)) return;

        // Get all platforms in the movement direction
        List<GameObject> platforms = platformDetector.DetectPlatforms(CheckMoveDir());

        foreach (GameObject platform in platforms)
        {
            if (platform != null && platform.CompareTag("Breakable"))
            {
                Debug.Log($"Destroyed: {platform.name}");
                Destroy(platform);
            }
        }
    }


    bool IsSize(int size)
    {
        return playerController._currentSizeIndex == size;
    }

    Vector2 CheckMoveDir()
    {
        return playerController._frameVelocity.x >= 0 ? Vector2.right : Vector2.left;
    }
}