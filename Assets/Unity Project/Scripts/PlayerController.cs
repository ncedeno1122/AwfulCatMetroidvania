using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Range(1f, 100f)]
    public float MOVE_SPEED = 15f;
    [Range(1f, 100f)]
    public float JUMP_FORCE = 5f;
    [Range(1f, 10f)]
    public float GROUNDED_DRAG_FORCE = 2f;

    [SerializeField]
    private bool m_IsGrounded = true;
    public bool IsGrounded { get => m_IsGrounded; set => m_IsGrounded = value; }

    [SerializeField]
    private bool m_IsFalling = false;
    public bool IsFalling { get => m_IsFalling; set => m_IsFalling = value; }

    public int m_NumberJumps = 2;

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

    private void Awake()
    {
        m_FireProjectileScript = GetComponent<FireProjectileScript>();

        m_PlayerInput = GetComponent<PlayerInput>();
        m_MoveAction = m_PlayerInput.actions["Move"];
        m_JumpAction = m_PlayerInput.actions["Jump"];
        m_FireAction = m_PlayerInput.actions["Fire"];
        m_InteractAction = m_PlayerInput.actions["Interact"];

        m_rb2d = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        CurrentState = new PlayerMoveState(this);
    }

    private void FixedUpdate()
    {
        CurrentState.OnFixedUpdate();
    }

    // + + + + | Input Events | + + + + 

    public void OnMove(InputAction.CallbackContext ctx)
    {
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

    // + + + + | Functions | + + + + 

    private void HandleJumpInput()
    {
        if (m_IsGrounded && m_NumberJumps > 0)
        {   
            Jump();
        }
        else
        {
            if (m_NumberJumps > 0)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        //Debug.Log("Jump!");
        m_IsGrounded = false;
        m_Animator.SetBool("IsGrounded", false);
        m_NumberJumps--;
        m_rb2d.velocity = new Vector2(m_rb2d.velocity.x * 0.5f, JUMP_FORCE);
    }
}
