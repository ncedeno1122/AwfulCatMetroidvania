using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessColliderScript : MonoBehaviour
{
    // + + + + | Collision Handling | + + + + 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        var blessHandler = collision.gameObject.GetComponent<BlessInteractionHandler>();
        if (blessHandler == null) return;

        blessHandler.HandleBless(); // TODO: Pass in collision and/or this object? Probably no reason to...
    }
}
