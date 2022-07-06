using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThroughTile : LevelTileGOScript
{
    private bool m_IsBroken = false;
    private bool m_IsPlayerInBlock = false;
    private float m_SpriteWidthWorld;
    private float m_SpriteHeightWorld;
    private IEnumerator m_BreakAndRegenCRT;

    private ParticleSystem m_Particle;
    private SpriteRenderer m_SpriteRenderer;

    private void Awake()
    {
        m_Particle = transform.GetChild(0).GetComponent<ParticleSystem>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteWidthWorld = m_SpriteRenderer.sprite.texture.width * m_SpriteRenderer.sprite.pixelsPerUnit;
        m_SpriteHeightWorld = m_SpriteRenderer.sprite.texture.height * m_SpriteRenderer.sprite.pixelsPerUnit;
    }

    // + + + + | Functions | + + + + 

    public override void TriggerTileEffect() => TryBreakAndRegenCRT();

    private void TryBreakAndRegenCRT()
    {
        if (m_IsBroken) return;
        //Debug.Log("Triggered! -> TryingToBreakAndRegen!");
        m_BreakAndRegenCRT = BreakAndRegenCRT(2f);
        StartCoroutine(m_BreakAndRegenCRT);
    }

    private IEnumerator BreakAndRegenCRT(float breakTime)
    {
        InvokeRequestTileDelete(transform.position);
        m_IsBroken = true;
        m_AllowProjectilesThrough = true;
        m_Particle.Play();

        do
        {
            yield return new WaitForSeconds(breakTime);
        }
        while (m_IsPlayerInBlock);

        // When the Player leaves the block
        InvokeRequestTileRestore(transform.position);
        m_IsBroken = false;
        m_AllowProjectilesThrough = false;
        m_Particle.Stop();
    }

    private bool IsPositionAboveTile(Vector3 collisionPosition)
    {
        return collisionPosition.y >= transform.position.y &&
               (collisionPosition.x >= transform.position.x - m_SpriteWidthWorld / 2 &&
               collisionPosition.x <= transform.position.x + m_SpriteWidthWorld / 2);
    }

    // + + + + | Collision Handling | + + + +

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && IsPositionAboveTile(collision.transform.position)) // TODO: Check within X range?
        {
            TriggerTileEffect();
        }
        else if (collision.CompareTag("Projectile") && !m_AllowProjectilesThrough)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (m_IsBroken)
            {
                m_IsPlayerInBlock = true;
            }
            else
            {
                if (IsPositionAboveTile(collision.transform.position))
                {
                    TriggerTileEffect();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_IsPlayerInBlock = false;
        }
    }
}
