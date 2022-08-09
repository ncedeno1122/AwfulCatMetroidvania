using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AchikSpiritFormState : PlayerState
{
    private readonly float SpiritFormSpeed;

    public AchikSpiritFormState(PlayerController context, float spiritFormSpeed) : base(context)
    {
        SpiritFormSpeed = spiritFormSpeed;
    }

    public override void Enter()
    {
        Debug.Log("Entering AchikSpiritFormState!");
        m_rb2d.gravityScale = 0f;
    }

    public override void Exit()
    {
        Debug.Log("Exiting AchikSpiritFormState!");
        m_rb2d.gravityScale = 1f;
    }

    public override void OnFixedUpdate()
    {
        m_rb2d.MovePosition(m_rb2d.position + (m_Context.MovementInput * (SpiritFormSpeed * Time.deltaTime)));
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