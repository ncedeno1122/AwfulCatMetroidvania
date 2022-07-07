using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableTile : LevelTileGOScript
{
    public const float SECONDS_TO_RESTORE = 2f;

    private bool m_IsBroken = false;
    public bool IsBroken { get => m_IsBroken; }

    private bool m_IsPlayerInBlock = false;
    public bool IsPlayerInBlock { get => m_IsPlayerInBlock; }
    private IEnumerator m_BreakAndRegenCRT;

    private ParticleSystem m_Particle;

    private void Awake()
    {
        m_Particle = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // + + + + | Functions | + + + + 

    public override void TriggerTileEffect()=>TryBreakAndRegenCRT();

    private void TryBreakAndRegenCRT()
    {
        if (m_IsBroken) return;
        m_BreakAndRegenCRT = BreakAndRegenCRT(SECONDS_TO_RESTORE);
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

    // + + + + | Collision Handling | + + + +

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
