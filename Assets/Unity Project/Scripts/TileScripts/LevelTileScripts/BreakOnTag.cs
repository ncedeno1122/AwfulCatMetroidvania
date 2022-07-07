using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BreakableTile))]
public class BreakOnTag : MonoBehaviour
{
    public List<string> TagsToBreakFor;

    private BreakableTile m_BreakableTile;

    private void Awake()
    {
        m_BreakableTile = GetComponent<BreakableTile>();
    }

    // + + + + | Functions | + + + +

    // + + + + | Collision Handling | + + + +

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TagsToBreakFor.Contains(collision.tag))
        {
            if (!m_BreakableTile.IsBroken)
            {
                m_BreakableTile.TriggerTileEffect();
                Destroy(collision.gameObject);
            }
        }
    }

}
