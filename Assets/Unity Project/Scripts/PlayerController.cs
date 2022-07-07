using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Range(1f, 100f)]
    public float MOVE_SPEED = 15f;
    [Range(1f, 100f)]
    public float JUMP_FORCE = 5f;
    [Range(1f, 10f)]
    public float GROUNDED_DRAG_FORCE = 2f;
    [SerializeField]
    private bool m_IsGrounded = true;
    private bool m_IsFalling = false;
    public int m_NumberJumps = 2;

    private float m_AimTimer = 0f;
    [Range(0.2f, 2f)]
    private float AIMING_COOLDOWN_TIME = 1f;
    private bool m_WeaponReadyToFire = true;
    private const float FIRE_WEAPON_COOLDOWN = 0.25f;
    
    private Vector2 m_MovementInput = Vector2.zero;
    private IEnumerator m_FireWeaponCooldownCRT;

    public GameObject m_ProjectilePrefab;
    private Transform m_ProjectileSpawn;
    private PlayerInput m_PlayerInput;
    private InputAction m_MoveAction, m_JumpAction, m_FireAction, m_InteractAction;
    private Rigidbody2D m_rb2d;
    private Animator m_Animator;
    private SpriteRenderer m_SpriteRenderer;
    private InteractableTile m_TouchingInteractableTile;

    private void Awake()
    {
        m_PlayerInput = GetComponent<PlayerInput>();
        m_MoveAction = m_PlayerInput.actions["Move"];
        m_JumpAction = m_PlayerInput.actions["Jump"];
        m_FireAction = m_PlayerInput.actions["Fire"];
        m_InteractAction = m_PlayerInput.actions["Interact"];

        m_rb2d = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        m_ProjectileSpawn = transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        // Are we grounded?
        //var groundCheckCollider = Physics2D.OverlapBox(m_rb2d.position + (Vector2.down * (m_SpriteRenderer.size.y / 2f)), (Vector2.one * 0.25f), 0f, LayerMask.GetMask("PhysEnviro"));
        //m_IsGrounded = groundCheckCollider && groundCheckCollider.CompareTag("PhysEnviro");
        m_IsGrounded = Mathf.Abs(m_rb2d.velocity.y) <= 0.05f; // Some small number
        m_IsFalling = m_IsGrounded == false && m_rb2d.velocity.y < 0f;
        m_Animator.SetBool("IsGrounded", m_IsGrounded);
        m_Animator.SetBool("IsFalling", m_IsFalling);

        if (m_IsGrounded && m_NumberJumps < 2) m_NumberJumps = 2;

        // TODO: Add dampening / inertial force to run cycle

        // Move
        var velocityXValue = m_rb2d.velocity.x + (m_MovementInput.x * MOVE_SPEED * Time.fixedDeltaTime);
        if (m_MovementInput != Vector2.zero)
        {
            m_rb2d.velocity = new Vector2(Mathf.Clamp(velocityXValue, -MOVE_SPEED/3f, MOVE_SPEED/3f), m_rb2d.velocity.y);
        }
        else
        {
            //
            if (m_IsGrounded)
            {
                m_rb2d.velocity = new Vector2(m_rb2d.velocity.x * 0.75f, m_rb2d.velocity.y);
            }
            else
            {
                m_rb2d.velocity = new Vector2(m_rb2d.velocity.x, m_rb2d.velocity.y);
            }
        }

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

    // + + + + | Input Events | + + + + 

    public void OnMove(InputAction.CallbackContext ctx)
    {
        var inputVec2 = ctx.ReadValue<Vector2>();

        //if (m_MoveAction.WasPressedThisFrame())
        if (inputVec2 != m_MovementInput)
        {
            // Is our new X input different from our old one AND not zero?
            if (inputVec2.x != m_MovementInput.x && inputVec2.x != 0)
            {
                m_SpriteRenderer.flipX = inputVec2.x < 0 && inputVec2 != Vector2.zero;
            }

            // Flip to the proper facing direction based on X input alone, if aiming
            //if (inputVec2.x != 0 || (m_AimTimer < AIMING_COOLDOWN_TIME && inputVec2.y != 0))
            //{
            //    m_SpriteRenderer.flipX = inputVec2.x < 0 && inputVec2 != Vector2.zero;
            //}
        }

        // Update MovementInput
        m_MovementInput = inputVec2;

        // Animator
        m_Animator.SetInteger("XInputInt", (int)inputVec2.x);
        m_Animator.SetInteger("YInputInt", (int)inputVec2.y);
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (m_JumpAction.WasPerformedThisFrame()) HandleJumpInput();
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (m_FireAction.WasPressedThisFrame())
        {
            if (m_WeaponReadyToFire)
            {
                // Create Projectile
                CreateProjectile();

                //Debug.Log("Can fire weapon!");
                m_FireWeaponCooldownCRT = FireWeaponCooldownCRT();
                StartCoroutine(m_FireWeaponCooldownCRT);
            }
            else
            {
                //Debug.Log("Sorry, can't fire weapon...");
            }
        }
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (m_InteractAction.WasPressedThisFrame())
        {
            if (m_TouchingInteractableTile)
            {
                m_TouchingInteractableTile.TriggerTileEffect();
            }
        }
    }

    // + + + + | Functions | + + + + 

    private void HandleJumpInput()
    {
        if (m_IsGrounded && m_NumberJumps > 0)
        {   
            Jump();
        }
        else
        {
            if (m_NumberJumps > 0)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        //Debug.Log("Jump!");
        m_IsGrounded = false;
        m_Animator.SetBool("IsGrounded", false);
        m_NumberJumps--;
        //m_rb2d.AddForce(Vector2.up * JUMP_FORCE, ForceMode2D.Impulse);
        m_rb2d.velocity = new Vector2(m_rb2d.velocity.x * 0.5f, JUMP_FORCE);
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

    private void CreateProjectile()
    {
        // Calculate Shooting Angle and Position
        var shootingAngle = 0f;
        var spawnPosition = Vector3.zero;
        if (!m_SpriteRenderer.flipX)
        {
            shootingAngle += (m_MovementInput.y != 0f ? (m_MovementInput.y > 0 ? 45f : -45f) : 0f);
            spawnPosition = transform.position + m_ProjectileSpawn.localPosition;
        }
        else
        {
            shootingAngle = 180f + (m_MovementInput.y != 0f ? (m_MovementInput.y > 0 ? -45f : 45f) : 0f);
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

    // + + + + | Collision Detection | + + + + 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.CompareTag("PhysEnviro") && collision.transform.position.y < transform.position.y)
        //{
        //    m_IsGrounded = true;
        //    m_Animator.SetBool("IsGrounded", true);
        //}

        if (collision.collider.isTrigger)
        {
            // TODO: Is this an InteractableTile?
            var interactableTileScript = collision.gameObject.GetComponent<InteractableTile>();
            if (interactableTileScript != null)
            {
                m_TouchingInteractableTile = interactableTileScript;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.collider.CompareTag("PhysEnviro") && collision.transform.position.y < transform.position.y)
        //{
        //    m_IsGrounded = false;
        //    m_Animator.SetBool("IsGrounded", false);
        //}

        if (collision.collider.isTrigger)
        {
            var interactableTileScript = collision.gameObject.GetComponent<InteractableTile>();
            if (m_TouchingInteractableTile && m_TouchingInteractableTile.Equals(interactableTileScript))
            {
                m_TouchingInteractableTile = null;
            }
        }
    }
}
