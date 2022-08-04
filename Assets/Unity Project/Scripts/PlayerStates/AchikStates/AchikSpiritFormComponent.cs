using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class AchikSpiritFormComponent : MonoBehaviour
{
    // Range?
    public float SkillDurationSeconds = 1.5f;
    public float SpiritFormSpeed = 1.5f;
    private Vector2 m_OldColliderDimensions;
    private Vector2 m_NewColliderDimensions = new Vector2(0.5f, 0.5f);
    private Vector2 m_OldColliderOffset;
    private Vector2 m_NewColliderOffset = Vector2.zero;

    private PlayerController m_PlayerController;
    private SpriteRenderer m_SpriteRenderer;
    private Animator m_Animator;
    private BoxCollider2D m_BoxCollider2D;

    private void Awake()
    {
        m_PlayerController = GetComponent<PlayerController>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_BoxCollider2D = GetComponent<BoxCollider2D>();
        m_Animator = GetComponent<Animator>();

        //
        m_OldColliderDimensions = m_BoxCollider2D.size;
        m_OldColliderOffset = m_BoxCollider2D.offset;
    }

    // + + + + | Functions | + + + + 

    public void ActivateSkill()
    {
        Debug.Log("Activating Spirit Form!");

        // Animator
        m_Animator.SetBool("SpiritFormActive", true);
        
        // Change Collider Size
        m_BoxCollider2D.size = m_NewColliderDimensions;
        m_BoxCollider2D.offset = m_NewColliderOffset;
        m_BoxCollider2D.edgeRadius = 0f;

        // Change State
        m_PlayerController.ChangeState(new AchikSpiritFormState(m_PlayerController, SpiritFormSpeed));

        // Start CRT!
        StartCoroutine(SkillDurationCRT(SkillDurationSeconds));
    }

    public void DeactivateSkill()
    {
        Debug.Log("Deactivating Spirit Form!");
        
        // Animator
        m_Animator.SetBool("SpiritFormActive", false);

        //
        MoveToValidColliderPosition();

        // Restore Collider Size
        m_BoxCollider2D.size = m_OldColliderDimensions;
        m_BoxCollider2D.offset = m_OldColliderOffset;
        m_BoxCollider2D.edgeRadius = 0.1f;

        // Restore State
        if (m_PlayerController.IsGrounded)
        {
            m_PlayerController.ChangeState(new AchikGroundState(m_PlayerController));
        }
        else
        {
            m_PlayerController.ChangeState(new AchikAirState(m_PlayerController));
        }

    }

    private IEnumerator SkillDurationCRT(float duration)
    {
        float currTime = 0f;

        while (currTime < duration)
        {
            currTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        DeactivateSkill();
    }

    private void MoveToValidColliderPosition()
    {
        var rb2d = m_BoxCollider2D.attachedRigidbody;

        // Left Cast
        var leftCastPosition = new Vector2(rb2d.position.x - (m_BoxCollider2D.size.x / 2f),
            rb2d.position.y - (m_BoxCollider2D.size.y / 2f));
        RaycastHit2D downwardsCastLeft = Physics2D.Raycast(leftCastPosition, Vector2.down, m_OldColliderDimensions.y, LayerMask.GetMask("PhysEnviro"));

        var rightCastPosition = new Vector2(rb2d.position.x + (m_BoxCollider2D.size.x / 2f),
            rb2d.position.y - (m_BoxCollider2D.size.y / 2f));
        RaycastHit2D downwardsCastRight = Physics2D.Raycast(rightCastPosition, Vector2.down, m_OldColliderDimensions.y, LayerMask.GetMask("PhysEnviro"));

        Vector2 finalPosition = (Vector2) transform.position;
        if (downwardsCastLeft.collider && downwardsCastRight.collider)
        {
            // Change position to whichever hit is CLOSER to us
            var closerHit = (downwardsCastLeft.point.y < downwardsCastRight.point.y) ? downwardsCastRight : downwardsCastLeft;
            transform.position = new Vector2(finalPosition.x, finalPosition.y + ((finalPosition.y - closerHit.point.y) + m_OldColliderDimensions.y / 2f + m_OldColliderOffset.y / 2f));
        }
        else if (downwardsCastLeft.collider && !downwardsCastRight.collider) // Only left
        {
            transform.position = new Vector2(finalPosition.x, finalPosition.y + ((finalPosition.y - downwardsCastLeft.point.y) + m_OldColliderDimensions.y / 2f + m_OldColliderOffset.y / 2f));
        }
        else if (!downwardsCastLeft.collider && downwardsCastRight.collider) // Only Right
        {
            transform.position = new Vector2(finalPosition.x, finalPosition.y + ((finalPosition.y - downwardsCastRight.point.y) + m_OldColliderDimensions.y / 2f + m_OldColliderOffset.y / 2f));
        }
    }
}
