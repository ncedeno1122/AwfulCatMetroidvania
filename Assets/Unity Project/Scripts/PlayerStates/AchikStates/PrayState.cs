using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrayState : SkillState
{
    public float AttiniyRegenerationRate = 5f;

    public PrayState(PlayerController context, PrayComponent blessComponent) : base(context, blessComponent)
    {
        this.skillComponent = blessComponent;
    }

    public override void Enter()
    {
        Debug.Log("Entering PrayState!");
        m_Context.Animator.SetBool("BlessingActive", true); // TODO: Change to unique animation?
    }

    public override void Exit()
    {
        Debug.Log("Exiting PrayState!");
        m_Context.Animator.SetBool("BlessingActive", false);
    }

    public override void OnFixedUpdate()
    {
        // TODO: May need to break here too!
        if (!m_Context.SkillActionHold.IsPressed())
        {
            // Get out of the state.
            //m_Context.TryChangeState(new AchikGroundState(m_Context));
            skillComponent.DeactivateSkill();
        }

        // Otherwise, increase Attiniy.
        m_Context.AchikComponent.AttiniyComponent.IncreaseAmountBy(AttiniyRegenerationRate * Time.fixedDeltaTime, false);
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
        if (ctx.performed && ctx.canceled)
        {
            // Get out of the state.
            //m_Context.TryChangeState(new AchikGroundState(m_Context));
            skillComponent.DeactivateSkill();
        }
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
