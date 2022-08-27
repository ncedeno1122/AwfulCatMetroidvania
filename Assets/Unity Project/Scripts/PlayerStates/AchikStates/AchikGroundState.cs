using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AchikGroundState : PlayerState
{
    public AchikGroundState(PlayerController context) : base(context)
    {
    }

    public override void Enter()
    {
        Debug.Log("Entered AchikGroundState!");
        m_Context.NumberJumps = m_Context.MaxJumps;

        m_Context.IsGrounded = true;
        m_Context.Animator.SetBool("IsGrounded", true);
        m_Context.IsFalling = false;
        m_Context.Animator.SetBool("IsFalling", false);
    }

    public override void Exit()
    {
        Debug.Log("Exiting AchikGroundState!");
    }

    public override void OnFixedUpdate()
    {
        m_Context.IsGrounded = Mathf.Abs(m_rb2d.velocity.y) <= 0.05f; // Some small number

        if (!m_Context.IsGrounded) m_Context.TryChangeState(new AchikAirState(m_Context));
        else
        {
            // Move
            var velocityXValue = m_rb2d.velocity.x + (m_Context.MovementInput.x * m_Context.MOVE_SPEED * Time.fixedDeltaTime);
            if (m_Context.MovementInput != Vector2.zero)
            {
                m_rb2d.velocity = new Vector2(Mathf.Clamp(velocityXValue, -m_Context.MOVE_SPEED / 3f, m_Context.MOVE_SPEED / 3f), m_rb2d.velocity.y);
            }
            else
            {
                m_rb2d.velocity = new Vector2(m_rb2d.velocity.x * 0.75f, m_rb2d.velocity.y);
            }
        }
    }

    // + + + + | InputActions | + + + +

    public override void OnFire(InputAction.CallbackContext ctx)
    {
        if (m_Context.FireAction.WasPressedThisFrame())
        {
            m_Context.FireProjectileScript.TryFire(m_Context.MovementInput, m_Context.SpriteRenderer.flipX);
        }
    }

    public override void OnInteract(InputAction.CallbackContext ctx)
    {
        //
    }

    public override void OnJump(InputAction.CallbackContext ctx)
    {
        if (m_Context.JumpAction.WasPerformedThisFrame()) m_Context.TryChangeState(new AchikJumpState(m_Context));
    }

    public override void OnMove(InputAction.CallbackContext ctx)
    {
        //
    }

    public override void OnSkill(InputAction.CallbackContext ctx)
    {
        SkillInput skillInput = new SkillInput();

        if (m_Context.MovementInput != Vector2.zero)
        {
            // Up
            if (Mathf.Abs(Vector2.Angle(m_Context.MovementInput.normalized, Vector2.up)) < 15f)
            {
                skillInput.direction = MoveInputDirection.UP;
            }
            // Down
            if (Mathf.Abs(Vector2.Angle(m_Context.MovementInput.normalized, Vector2.down)) < 15f)
            {
                skillInput.direction = MoveInputDirection.DOWN;
            }
            // Right
            if (Mathf.Abs(Vector2.Angle(m_Context.MovementInput.normalized, Vector2.right)) < 15f)
            {
                skillInput.direction = MoveInputDirection.HORIZONTAL;
            }
            // Left
            if (Mathf.Abs(Vector2.Angle(m_Context.MovementInput.normalized, Vector2.left)) < 15f)
            {
                skillInput.direction = MoveInputDirection.HORIZONTAL;
            }
        }
        else
        {
            skillInput.direction = MoveInputDirection.NEUTRAL;
        }

        // To AchikComponent's HandleInput
        skillInput.activationType = InputActivationType.SINGLETAP;
        skillInput.isGrounded = m_Context.IsGrounded;
        m_Context.AchikComponent.HandleInput(skillInput);
    }

    // + + + + | Collisions | + + + +

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
