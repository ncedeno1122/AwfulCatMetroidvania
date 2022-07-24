using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerState
{
    protected PlayerController m_Context;

    // Should be able to access InputActions from context

    // + + + + | Functions | + + + +

    public PlayerState(PlayerController context)
    {
        m_Context = context;
    }

    public abstract void Enter();
    public abstract void Exit();

    public abstract void OnFixedUpdate();

    public abstract void OnMove(InputAction.CallbackContext ctx);
    public abstract void OnJump(InputAction.CallbackContext ctx);
    public abstract void OnFire(InputAction.CallbackContext ctx);
    public abstract void OnInteract(InputAction.CallbackContext ctx);
}
