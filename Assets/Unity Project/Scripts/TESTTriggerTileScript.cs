using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTTriggerTileScript : MonoBehaviour
{
    private void OnValidate()
    {
        Debug.Log("Greetings from TESTTriggerTileScript!");
    }

    // + + + + | Collision Handling | + + + +

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Debug.Log($"A player entered {gameObject.name}!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Debug.Log($"A player exited {gameObject.name}!");
    }
}
