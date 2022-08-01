using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerState
{
    protected PlayerController m_Context;
    protected Rigidbody2D m_rb2d;

    // Should be able to access InputActions from context

    // + + + + | Functions | + + + +

    public PlayerState(PlayerController context)
    {
        m_Context = context;
        m_rb2d = context.Rb2d;
    }

    public abstract void Enter();
    public abstract void Exit();

    public abstract void OnFixedUpdate();

    public abstract void OnMove(InputAction.CallbackContext ctx);
    public abstract void OnJump(InputAction.CallbackContext ctx);
    public abstract void OnFire(InputAction.CallbackContext ctx);
    public abstract void OnInteract(InputAction.CallbackContext ctx);
    public abstract void OnSkill(InputAction.CallbackContext ctx);

    // TODO: Add Collision Wrapper Functions
    public abstract void OnCollisionEnter2D(Collision2D collision);
    public abstract void OnCollisionStay2D(Collision2D collision);
    public abstract void OnCollisionExit2D(Collision2D collision);
}
