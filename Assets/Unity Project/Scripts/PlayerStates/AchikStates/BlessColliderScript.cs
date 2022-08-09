using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessColliderScript : MonoBehaviour
{
    // + + + + | Collision Handling | + + + + 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        else
        {
            // If something is listening to being blessed, make it react!
            // if (collision.gameObject.GetComponent<BlessListener>()) ...
        }
    }
}
