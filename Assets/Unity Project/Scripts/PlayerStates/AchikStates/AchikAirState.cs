using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AchikAirState : PlayerState
{
    public AchikAirState(PlayerController context) : base(context)
    {
    }

    public override void Enter()
    {
        Debug.Log("Entered AchikAirState!");

        if (!m_Context.IsGrounded)
        {
            m_Context.IsGrounded = false;
            m_Context.Animator.SetBool("IsGrounded", false);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting AchikAirState!");
    }

    public override void OnFixedUpdate()
    {
        // Falling Anim
        if (!m_Context.IsGrounded && !m_Context.IsFalling && m_rb2d.velocity.y < 0f)
        {
            m_Context.IsFalling = true;
            m_Context.Animator.SetBool("IsFalling", true);
        }

        // Air Directional Influence
        var velocityXValue = m_rb2d.velocity.x + (m_Context.MovementInput.x * m_Context.MOVE_SPEED * Time.fixedDeltaTime);
        if (m_Context.MovementInput != Vector2.zero)
        {
            m_rb2d.velocity = new Vector2(Mathf.Clamp(velocityXValue, -m_Context.MOVE_SPEED / 5f, m_Context.MOVE_SPEED / 5f), m_rb2d.velocity.y);
        }
    }

    //

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
        if (m_Context.JumpAction.WasPressedThisFrame()) m_Context.ChangeState(new AchikJumpState(m_Context));
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

    //

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
        if (collision.gameObject.CompareTag("PhysEnviro"))
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                var currContact = collision.GetContact(i);
                if (m_Context.CheckIfValidGroundPoint(currContact.point))
                {
                    // Land!
                    Debug.Log($"Landed for contact point {currContact.point} | Diff: {(Vector2)m_Context.transform.position - currContact.point}!");
                    m_Context.ChangeState(new AchikGroundState(m_Context));
                }
            }
        }
    }
}
