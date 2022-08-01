using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerController context) : base(context)
    {
    }

    public override void Enter()
    {
        Debug.Log("Entered PlayerMove!");
    }

    public override void Exit()
    {
        Debug.Log("Exited PlayerMove!");
    }

    public override void OnFire(InputAction.CallbackContext ctx)
    {
        if (m_Context.FireAction.WasPressedThisFrame())
        {
            m_Context.FireProjectileScript.TryFire(m_Context.MovementInput, m_Context.SpriteRenderer.flipX);
        }
    }

    public override void OnFixedUpdate()
    {
        // Are we grounded?
        //var groundCheckCollider = Physics2D.OverlapBox(m_rb2d.position + (Vector2.down * (m_SpriteRenderer.size.y / 2f)), (Vector2.one * 0.25f), 0f, LayerMask.GetMask("PhysEnviro"));
        //m_IsGrounded = groundCheckCollider && groundCheckCollider.CompareTag("PhysEnviro");
        m_Context.IsGrounded = Mathf.Abs(m_rb2d.velocity.y) <= 0.05f; // Some small number
        m_Context.IsFalling = m_Context.IsGrounded == false && m_rb2d.velocity.y < 0f;
        m_Context.Animator.SetBool("IsGrounded", m_Context.IsGrounded);
        m_Context.Animator.SetBool("IsFalling", m_Context.IsFalling);

        if (m_Context.IsGrounded && m_Context.NumberJumps < 2) m_Context.NumberJumps = 2;

        // TODO: Add dampening / inertial force to run cycle

        // Move
        var velocityXValue = m_rb2d.velocity.x + (m_Context.MovementInput.x * m_Context.MOVE_SPEED * Time.fixedDeltaTime);
        if (m_Context.MovementInput != Vector2.zero)
        {
            m_rb2d.velocity = new Vector2(Mathf.Clamp(velocityXValue, -m_Context.MOVE_SPEED / 3f, m_Context.MOVE_SPEED / 3f), m_rb2d.velocity.y);
        }
        else
        {
            //
            if (m_Context.IsGrounded)
            {
                m_rb2d.velocity = new Vector2(m_rb2d.velocity.x * 0.75f, m_rb2d.velocity.y);
            }
            else
            {
                m_rb2d.velocity = new Vector2(m_rb2d.velocity.x, m_rb2d.velocity.y);
            }
        }
    }

    public override void OnInteract(InputAction.CallbackContext ctx)
    {
        //
    }

    public override void OnJump(InputAction.CallbackContext ctx)
    {
        if (m_Context.JumpAction.WasPerformedThisFrame()) HandleJumpInput();
    }

    public override void OnMove(InputAction.CallbackContext ctx)
    {
        var inputVec2 = ctx.ReadValue<Vector2>();

        if (inputVec2 != m_Context.MovementInput)
        {
            // Is our new X input different from our old one AND not zero?
            if (inputVec2.x != m_Context.MovementInput.x && inputVec2.x != 0)
            {
                m_Context.SpriteRenderer.flipX = inputVec2.x < 0 && inputVec2 != Vector2.zero;
            }
        }

        // Update MovementInput
        m_Context.MovementInput = inputVec2;

        // Animator
        m_Context.Animator.SetInteger("XInputInt", (int)inputVec2.x);
        m_Context.Animator.SetInteger("YInputInt", (int)inputVec2.y);
    }

    public override void OnSkill(InputAction.CallbackContext ctx)
    {
        if (!m_Context.SkillAction.WasPerformedThisFrame()) return;

        // Directional Input?
        var input = m_Context.MovementInput; 

        if (input.x == 0f && input.y == 0f) // Deadzones are useful here...
        {
            // Default Special
            Debug.Log("Default Special!");
        }
        else if (input.x == 0f)
        {
            if (input.y > 0)
            {
                // UP
                Debug.Log("Up Special!");
            }
            else
            {
                // DOWN
                Debug.Log("Down Special!");
            }
        }
        else if (input.y == 0f)
        {
            if (input.x > 0)
            {
                // RIGHT
                Debug.Log("Right Special!");
            }
            else
            {
                // LEFT
                Debug.Log("Left Special!");
            }
        }
    }

    // + + + + | Functions | + + + +

    private void HandleJumpInput()
    {
        if (m_Context.IsGrounded && m_Context.NumberJumps > 0)
        {
            Jump();
        }
        else
        {
            if (m_Context.NumberJumps > 0)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        //Debug.Log("Jump!");
        m_Context.IsGrounded = false;
        m_Context.Animator.SetBool("IsGrounded", false);
        m_Context.NumberJumps--;
        m_rb2d.velocity = new Vector2(m_rb2d.velocity.x * 0.5f, m_Context.JUMP_FORCE);
    }

    // + + + + | Collision Handling | + + + + 

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        //
    }

    public override void OnCollisionExit2D(Collision2D collision)
    {
        //
    }

    public override void OnCollisionStay2D(Collision2D collision)
    {
        //
    }
}
