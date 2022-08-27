using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class SkillState : PlayerState
{
    protected ISkill skillComponent;
    protected bool isSkillComplete;
    public bool IsSkillComplete { get => skillComponent.IsComplete; } // Points to ISkill's completion state.

    protected SkillState(PlayerController context, ISkill skillComponent) : base(context)
    {
    }

    //
    public abstract override void Enter();

    public abstract override void Exit();

    public abstract override void OnFixedUpdate();

    public abstract override void OnCollisionEnter2D(Collision2D collision);

    public abstract override void OnCollisionExit2D(Collision2D collision);

    public abstract override void OnCollisionStay2D(Collision2D collision);

    public abstract override void OnFire(InputAction.CallbackContext ctx);

    public abstract override void OnInteract(InputAction.CallbackContext ctx);

    public abstract override void OnJump(InputAction.CallbackContext ctx);

    public abstract override void OnMove(InputAction.CallbackContext ctx);

    public abstract override void OnSkill(InputAction.CallbackContext ctx);
}
