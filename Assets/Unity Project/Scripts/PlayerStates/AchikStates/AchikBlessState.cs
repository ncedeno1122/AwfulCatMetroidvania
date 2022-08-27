using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AchikBlessState : SkillState
{
    public AchikBlessState(PlayerController context, BlessComponent blessComponent) : base(context, blessComponent)
    {
        this.skillComponent = blessComponent;
    }

    public override void Enter()
    {
        Debug.Log("Entering AchikBlessState!");
        m_Context.Animator.SetBool("BlessingActive", true);
    }

    public override void Exit()
    {
        Debug.Log("Exiting AchikBlessState!");
        m_Context.Animator.SetBool("BlessingActive", false);
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
