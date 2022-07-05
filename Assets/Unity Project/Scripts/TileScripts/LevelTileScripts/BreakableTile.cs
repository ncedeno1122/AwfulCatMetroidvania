using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableTile : LevelTileGOScript
{
    private bool m_IsBroken = false;
    private bool m_IsPlayerInBlock = false;
    private IEnumerator m_BreakAndRegenCRT;

    // + + + + | Functions | + + + + 

    public override void TriggerTileEffect()=>TryBreakAndRegenCRT();

    private void TryBreakAndRegenCRT()
    {
        if (m_IsBroken) return;
        Debug.Log("Triggered! -> TryingToBreakAndRegen!");
        m_BreakAndRegenCRT = BreakAndRegenCRT(2f);
        StartCoroutine(m_BreakAndRegenCRT);
    }

    private IEnumerator BreakAndRegenCRT(float breakTime)
    {
        InvokeRequestTileDelete(transform.position);
        m_IsBroken = true;
        m_AllowProjectilesThrough = true;

        do
        {
            yield return new WaitForSeconds(breakTime);
        }
        while (m_IsPlayerInBlock);

        // When the Player leaves the block
        InvokeRequestTileRestore(transform.position);
        m_IsBroken = false;
        m_AllowProjectilesThrough = false;
    }

    // + + + + | Collision Handling | + + + +

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            TryBreakAndRegenCRT();
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
