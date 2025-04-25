using UnityEngine;
using System.Collections.Generic;

public class PlatformDetector : MonoBehaviour
{
    public float detectionDistance = 1f;      // Distance to check below the player
    public LayerMask platformLayer;           // What constitutes a platform
    public float verticalOffsetStep = 1f;     // Height step between each raycast
    public int raycastCount = 3;              // Number of raycasts (e.g., 3 for this case)

    // Detect platforms below the player at increasing heights
    public List<GameObject> DetectPlatforms(Vector2 direction)
    {
        List<GameObject> hitPlatforms = new List<GameObject>();

        for (int i = 0; i < raycastCount; i++)
        {
            Vector2 offsetPosition = (Vector2)transform.position + Vector2.up * (verticalOffsetStep * i);
            RaycastHit2D hit = Physics2D.Raycast(offsetPosition, direction, detectionDistance, platformLayer);

            Debug.DrawLine(offsetPosition, offsetPosition + direction * detectionDistance, Color.red, 1f);

            if (hit.collider != null)
            {
                Debug.Log($"Hit at height {i}: {hit.collider.gameObject.name}");
                hitPlatforms.Add(hit.collider.gameObject);
            }
        }

        return hitPlatforms;
    }

    // Optional: draw all the raycasts in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < raycastCount; i++)
        {
            Vector3 startPos = transform.position + Vector3.up * (verticalOffsetStep * i);
            Gizmos.DrawLine(startPos, startPos + Vector3.down * detectionDistance);
        }
    }
}
