using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredProjectile : MonoBehaviour
{
    private const float PROJECTILE_SPEED = 2f;
    private Rigidbody2D m_rb2d;

    private void Awake()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke(nameof(WrapDestroy), 3f);
    }

    // + + + + | Functions | + + + +

    private void WrapDestroy()
    {
        Destroy(gameObject);
    }

    // + + + + | Collision Handling | + + + 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("LevelTileGO"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("LevelTileGO"))
        {
            var tileScript = collision.gameObject.GetComponent<LevelTileGOScript>();
            tileScript.TriggerTileEffect();
            if (!tileScript.AllowProjectilesThrough)
                Destroy(gameObject);
        }
    }
}
