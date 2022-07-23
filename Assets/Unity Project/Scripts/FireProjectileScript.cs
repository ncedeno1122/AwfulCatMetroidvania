using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileScript : MonoBehaviour
{
    private float m_AimTimer = 0f;
    [Range(0.2f, 2f)]
    private float AIMING_COOLDOWN_TIME = 1f;
    private bool m_WeaponReadyToFire = true;
    private const float FIRE_WEAPON_COOLDOWN = 0.25f;

    private IEnumerator m_FireWeaponCooldownCRT;

    public GameObject m_ProjectilePrefab;
    public Transform m_ProjectileSpawn;
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();

        //m_ProjectileSpawn = transform.GetChild(0); // TODO: This scares me...
    }

    private void FixedUpdate()
    {
        // Update m_AimTimer
        // TODO: Move to CRT?
        if (m_AimTimer < AIMING_COOLDOWN_TIME)
        {
            m_AimTimer += Time.fixedDeltaTime;
            if (!m_Animator.GetBool("IsAiming"))
            {
                m_Animator.SetBool("IsAiming", true);
            }
        }
        else
        {
            if (m_Animator.GetBool("IsAiming"))
            {
                m_Animator.SetBool("IsAiming", false);
            }
        }
    }

    // + + + + | Functions | + + + +

    public void TryFire(Vector2 movementInput, bool flippedX)
    {
        if (m_WeaponReadyToFire)
        {
            // Create Projectile
            CreateProjectile(movementInput, flippedX);

            //Debug.Log("Can fire weapon!");
            m_FireWeaponCooldownCRT = FireWeaponCooldownCRT();
            StartCoroutine(m_FireWeaponCooldownCRT);
        }
        else
        {
            //Debug.Log("Sorry, can't fire weapon...");
        }
    }

    private void CreateProjectile(Vector2 movementInput, bool flippedX)
    {
        // Calculate Shooting Angle and Position
        var shootingAngle = 0f;
        Vector3 spawnPosition;
        if (!flippedX)
        {
            shootingAngle += (movementInput.y != 0f ? (movementInput.y > 0 ? 45f : -45f) : 0f);
            spawnPosition = transform.position + m_ProjectileSpawn.localPosition;
        }
        else
        {
            shootingAngle = 180f + (movementInput.y != 0f ? (movementInput.y > 0 ? -45f : 45f) : 0f);
            spawnPosition = transform.position + new Vector3(m_ProjectileSpawn.localPosition.x * -1, m_ProjectileSpawn.localPosition.y, 0f);
        }

        var cosVelo = Mathf.Cos(Mathf.Deg2Rad * shootingAngle);
        var sinVelo = Mathf.Sin(Mathf.Deg2Rad * shootingAngle);

        // Create Projectile at position
        var projectile = Instantiate(m_ProjectilePrefab, spawnPosition, Quaternion.identity);
        var projectileRb = projectile.GetComponent<Rigidbody2D>();

        // Launch the Projectile
        projectileRb.velocity = new Vector2(cosVelo, sinVelo) * 15f;
    }

    private IEnumerator FireWeaponCooldownCRT()
    {
        //Debug.Log("No shooty! (from CRT)");
        var elapsedFixedDeltaTime = 0f;
        m_WeaponReadyToFire = false;

        // Animation
        m_AimTimer = 0f; // Sets aiming animation to true
        m_Animator.SetTrigger("FireWeapon");

        while (elapsedFixedDeltaTime < FIRE_WEAPON_COOLDOWN)
        {
            elapsedFixedDeltaTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        m_WeaponReadyToFire = true;
        m_Animator.ResetTrigger("FireWeapon");
        //Debug.Log("Ok now shooty (done with CRT)");
    }


}
