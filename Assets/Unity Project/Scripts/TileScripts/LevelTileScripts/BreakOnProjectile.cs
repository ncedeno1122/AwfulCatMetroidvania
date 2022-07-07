using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BreakableTile))]
public class BreakOnProjectile : MonoBehaviour
{
    private BreakableTile m_BreakableTile;

    private void Awake()
    {
        m_BreakableTile = GetComponent<BreakableTile>();
    }

    // + + + + | Functions | + + + +



    // + + + + | Collision Handling | + + + +

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            if (!m_BreakableTile.IsBroken)
            {
                m_BreakableTile.TriggerTileEffect();
                Destroy(collision.gameObject);
            }
        }
    }

}
