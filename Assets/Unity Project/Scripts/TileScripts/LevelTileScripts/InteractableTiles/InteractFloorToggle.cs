using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableTile))]
public class InteractFloorToggle : MonoBehaviour
{
    private InteractableTile m_InteractableTile;
    private Collider2D m_Collider2D;

    private void Awake()
    {
        m_InteractableTile = GetComponent<InteractableTile>();
        m_Collider2D = GetComponent<Collider2D>();
    }

    // + + + + | Functions | + + + +

    private bool IsPositionAboveTile(Vector3 collisionPosition)
    {
        var closestPt = m_Collider2D.ClosestPoint(new Vector2(collisionPosition.x, collisionPosition.y));
        var difference = closestPt - new Vector2(transform.position.x, transform.position.y);

        return difference.x > -0.475f && difference.x < 0.475f && difference.y >= 0.5f;
    }

    // + + + + | Collision Handling | + + + +

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (IsPositionAboveTile(collision.transform.position))
            {
                m_InteractableTile.TriggerTileEffect();
            }
        }
        else if (collision.CompareTag("Projectile") && !m_InteractableTile.AllowProjectilesThrough)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (IsPositionAboveTile(collision.transform.position))
            {
                m_InteractableTile.TriggerTileEffect();
            }
        }
    }
}