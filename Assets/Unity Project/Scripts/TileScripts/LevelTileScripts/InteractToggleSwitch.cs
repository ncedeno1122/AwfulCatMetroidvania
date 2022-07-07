using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableTile))]
public class InteractToggleSwitch : MonoBehaviour
{
    private InteractableTile m_InteractableTile;

    private void Awake()
    {
        m_InteractableTile = GetComponent<InteractableTile>();
        m_InteractableTile.TileIsToggle = true;
    }

    // + + + + | Collision Handling | + + + +

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //TODO: Maybe make Interaction a Component...
            var playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController.IsInteracting)
            {
                m_InteractableTile.TriggerTileEffect();
            }
        }
    }
}
