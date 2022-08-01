using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AchikJumpState : PlayerState
{
    public AchikJumpState(PlayerController context) : base(context)
    {
    }

    public override void Enter()
    {
        //Debug.Log("Entered AchikJumpState!");

        // Can we Jump?
        if (m_Context.NumberJumps - 1 > 0)
        {
            m_Context.NumberJumps--;
            m_rb2d.velocity = new Vector2(m_rb2d.velocity.x * 0.5f, m_Context.JUMP_FORCE);

            m_Context.IsGrounded = false;
            m_Context.Animator.SetBool("IsGrounded", false);
            m_Context.IsFalling = false;
            m_Context.Animator.SetBool("IsFalling", false);

            m_Context.ChangeState(new AchikAirState(m_Context));
        }
        else
        {
            // If not, return to normal state.
            PlayerState nextState = (m_Context.IsGrounded) ? new AchikGroundState(m_Context) : new AchikAirState(m_Context);
            m_Context.ChangeState(nextState);
        }
    }

    public override void Exit()
    {
        //Debug.Log("Exiting AchikJumpState!");
    }

    public override void OnFixedUpdate()
    {
        //
    }

    //

    public override void OnFire(InputAction.CallbackContext ctx)
    {
        //
    }

    public override void OnInteract(InputAction.CallbackContext ctx)
    {
        //
    }

    public override void OnJump(InputAction.CallbackContext ctx)
    {
        //
    }

    public override void OnMove(InputAction.CallbackContext ctx)
    {
        //
    }

    public override void OnSkill(InputAction.CallbackContext ctx)
    {
        //
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
        //
    }
}
