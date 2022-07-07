using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BreakableTile))]
public class FallThroughTile : MonoBehaviour
{
    private float m_SpriteWidthWorld;
    private float m_SpriteHeightWorld;

    private BreakableTile m_BreakableTile;
    private SpriteRenderer m_SpriteRenderer;
    private Collider2D m_Collider2D;

    private void Awake()
    {
        m_BreakableTile = GetComponent<BreakableTile>();
        m_Collider2D = GetComponent<Collider2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteWidthWorld = m_SpriteRenderer.sprite.texture.width * m_SpriteRenderer.sprite.pixelsPerUnit;
        m_SpriteHeightWorld = m_SpriteRenderer.sprite.texture.height * m_SpriteRenderer.sprite.pixelsPerUnit;
    }

    // + + + + | Functions | + + + + 

    private bool IsPositionAboveTile(Vector3 collisionPosition)
    {
        var closestPt = m_Collider2D.ClosestPoint(new Vector2(collisionPosition.x, collisionPosition.y));
        var difference = closestPt - new Vector2(transform.position.x, transform.position.y);

        return difference.x > -0.475f && difference.x < 0.475f &&
               difference.y >= 0.5f;
        
    }

    // + + + + | Collision Handling | + + + +

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!m_BreakableTile.IsBroken && IsPositionAboveTile(collision.transform.position))
            {
                m_BreakableTile.TriggerTileEffect();
            }
        }
        else if (collision.CompareTag("Projectile") && !m_BreakableTile.AllowProjectilesThrough)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!m_BreakableTile.IsBroken && IsPositionAboveTile(collision.transform.position))
            {
                m_BreakableTile.TriggerTileEffect();
            }
        }
    }
}
