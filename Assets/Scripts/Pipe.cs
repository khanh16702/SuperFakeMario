using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public KeyCode enterKeyCode = KeyCode.S;
    public Vector3 enterDirection = Vector3.down;
    public Vector3 exitDirection = Vector3.zero;
    public Transform connection;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (connection != null && other.CompareTag("Player"))
        {
            if (Input.GetKey(enterKeyCode))
            {
                StartCoroutine(Enter(other.transform));
            }
        }
    }

    private IEnumerator Enter (Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        Vector3 enterPosition = transform.position + enterDirection;
        yield return Move(player, enterPosition);
        
    }
    private IEnumerator Move (Transform player, Vector3 endPosition)
    {
        float elapsed = 0f;
        float duration = 1f;
        Vector3 startPosition = player.position; 
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            player.position = Vector3.Lerp(startPosition, endPosition, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        player.position = endPosition;
    }
}
