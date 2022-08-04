using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Range(1f, 100f)]
    public float MOVE_SPEED = 15f;
    [Range(1f, 100f)]
    public float JUMP_FORCE = 5f;
    [Range(1f, 10f)]
    public float GROUNDED_DRAG_FORCE = 2f;
    public float GROUNDED_CHECK_WIDTH = 0.15f;

    [SerializeField]
    private bool m_IsGrounded = true;
    public bool IsGrounded { get => m_IsGrounded; set => m_IsGrounded = value; }

    [SerializeField]
    private bool m_IsFalling = false;
    public bool IsFalling { get => m_IsFalling; set => m_IsFalling = value; }

    [SerializeField]
    private int m_MaxJumps = 2;
    public int MaxJumps { get => m_MaxJumps; }
    
    [SerializeField]
    private int m_NumberJumps;
    public int NumberJumps { get => m_NumberJumps; set => m_NumberJumps = value; }

    [SerializeField]
    private bool m_IsInteracting;
    public bool IsInteracting { get => m_IsInteracting; }

    [SerializeField]
    private Vector2 m_MovementInput = Vector2.zero;
    public Vector2 MovementInput { get => m_MovementInput; set => m_MovementInput = value; }


    private PlayerInput m_PlayerInput;
    private InputAction m_MoveAction;
    public InputAction MoveAction { get => m_MoveAction; }
    private InputAction m_JumpAction;
    public InputAction JumpAction { get => m_JumpAction; }
    private InputAction m_FireAction;
    public InputAction FireAction { get => m_FireAction; }
    private InputAction m_InteractAction;
    public InputAction InteractAction { get => m_InteractAction;}
    private InputAction m_SkillAction;
    public InputAction SkillAction { get => m_SkillAction; }

    private Rigidbody2D m_rb2d;
    public Rigidbody2D Rb2d { get => m_rb2d; }
    private Animator m_Animator;
    public Animator Animator { get => m_Animator; }
    private SpriteRenderer m_SpriteRenderer;
    public SpriteRenderer SpriteRenderer { get => m_SpriteRenderer; }
    private FireProjectileScript m_FireProjectileScript;
    public FireProjectileScript FireProjectileScript { get => m_FireProjectileScript; }

    [SerializeReference]
    private InteractableTile m_TouchingInteractableTile;

    public PlayerState CurrentState;

    public UnityEvent ActivateAbility1;

    private void Awake()
    {
        m_NumberJumps = m_MaxJumps;

        //

        m_FireProjectileScript = GetComponent<FireProjectileScript>();

        m_PlayerInput = GetComponent<PlayerInput>();
        m_MoveAction = m_PlayerInput.actions["Move"];
        m_JumpAction = m_PlayerInput.actions["Jump"];
        m_FireAction = m_PlayerInput.actions["Fire"];
        m_InteractAction = m_PlayerInput.actions["Interact"];
        m_SkillAction = m_PlayerInput.actions["Skill"];

        m_rb2d = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        //CurrentState = new PlayerMoveState(this);
        CurrentState = new AchikAirState(this);
    }

    private void FixedUpdate()
    {
        CurrentState.OnFixedUpdate();
    }

    // + + + + | Input Events | + + + + 

    public void OnMove(InputAction.CallbackContext ctx)
    {
        var inputVec2 = ctx.ReadValue<Vector2>();

        if (inputVec2 != MovementInput)
        {
            // Is our new X input different from our old one AND not zero?
            if (inputVec2.x != MovementInput.x && inputVec2.x != 0)
            {
                SpriteRenderer.flipX = inputVec2.x < 0 && inputVec2 != Vector2.zero;
            }
        }

        // Update MovementInput
        MovementInput = inputVec2;

        // Animator
        Animator.SetInteger("XInputInt", (int)inputVec2.x);
        Animator.SetInteger("YInputInt", (int)inputVec2.y);

        // Finally, invoke CurrentState's OnMove
        CurrentState.OnMove(ctx);
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        CurrentState.OnJump(ctx);
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        CurrentState.OnFire(ctx);
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (InteractAction.WasPressedThisFrame())
        {
            m_IsInteracting = true;
        }
        if (InteractAction.WasReleasedThisFrame())
        {
            m_IsInteracting = false;
        }

        CurrentState.OnInteract(ctx);
    }

    public void OnSkill(InputAction.CallbackContext ctx)
    {
        if (!SkillAction.WasPerformedThisFrame()) return;

        // Directional Input?
        var input = MovementInput;

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

        // Finally, invoke OnSkill or Skill-specific functions in each state.
        CurrentState.OnSkill(ctx);
    }

    // + + + + | Functions | + + + + 

    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public bool CheckIfValidGroundPoint(Vector2 point)
    {
        Vector2 currPosition = new Vector2(transform.position.x, transform.position.y);
        return point.y < currPosition.y && point.x > currPosition.x - GROUNDED_CHECK_WIDTH && point.x < currPosition.x + GROUNDED_CHECK_WIDTH;
    }

    // + + + + | Collision Handling | + + + + 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CurrentState.OnCollisionEnter2D(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CurrentState.OnCollisionStay2D(collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        CurrentState.OnCollisionExit2D(collision);
    }
}
