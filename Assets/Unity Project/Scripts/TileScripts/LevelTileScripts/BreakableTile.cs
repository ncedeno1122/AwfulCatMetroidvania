using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableTile : LevelTileGOScript
{
    private bool m_IsBroken = false;
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

        yield return new WaitForSeconds(breakTime);

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
}
