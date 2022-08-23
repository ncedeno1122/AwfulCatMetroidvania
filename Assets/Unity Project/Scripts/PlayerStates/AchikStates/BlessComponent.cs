using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class BlessComponent : MonoBehaviour, ISkill
{
    public const float BLESSING_TIME = 0.5f;

    [SerializeField] private Vector2 m_InitialScale = new Vector2(0.1f, 0.1f);
    [SerializeField] private Vector2 m_FinalScale = new Vector2(2f, 2.25f);

    public BlessColliderScript m_BlessColliderScript;
    private Transform m_BlessTf;
    private SpriteRenderer m_BlessSpriteRenderer;
    private CapsuleCollider2D m_BlessCollider;

    private PlayerController m_PlayerController;
    private ParticleSystem m_Particle;

    private void Awake()
    {
        m_PlayerController = GetComponent<PlayerController>();

        if (!m_BlessColliderScript) return;
        m_BlessTf = m_BlessColliderScript.transform;
        m_Particle = m_BlessTf.GetComponent<ParticleSystem>();
        m_BlessCollider = m_BlessTf.GetComponent<CapsuleCollider2D>();
        m_BlessSpriteRenderer = m_BlessTf.GetComponent<SpriteRenderer>();

        //m_InitialScale = m_BlessTf.localScale;
        m_BlessColliderScript.gameObject.SetActive(false);
    }

    // + + + + | Functions | + + + + 

    private IEnumerator BlessCRT()
    {
        // Scale up
        float currTime = 0f;
        while (currTime <= BLESSING_TIME)
        {
            currTime += Time.fixedDeltaTime;
            //m_BlessTf.localScale = Vector2.Lerp(m_InitialScale, m_FinalScale, currTime / BLESSING_TIME);
            m_BlessCollider.size = Vector2.Lerp(m_InitialScale, m_FinalScale, currTime / BLESSING_TIME);
            m_BlessSpriteRenderer.size = Vector2.Lerp(m_InitialScale, m_FinalScale, currTime / BLESSING_TIME);
            yield return new WaitForFixedUpdate();
        }

        DeactivateSkill();
    }

    public void ActivateSkill()
    {
        // Activate & Start CRT
        //Debug.Log("Activating Skill: BlessComponent!");
        m_PlayerController.ChangeState(new AchikBlessState(m_PlayerController));
        
        m_BlessColliderScript.gameObject.SetActive(true);
        //if ((Vector2)m_BlessTf.localScale != m_InitialScale) m_BlessTf.localScale = m_InitialScale;
        m_BlessCollider.size = m_InitialScale;
        m_BlessSpriteRenderer.size = m_InitialScale;

        m_Particle.Play();

        StartCoroutine(BlessCRT());
    }

    public void DeactivateSkill()
    {
        // Deactivate and rescale
        //Debug.Log("Deactivating Skill: BlessComponent!");

        //m_BlessTf.localScale = m_InitialScale;
        m_BlessCollider.size = m_InitialScale;
        m_BlessSpriteRenderer.size = m_InitialScale;

        m_BlessColliderScript.gameObject.SetActive(false);

        m_PlayerController.ChangeState(new AchikGroundState(m_PlayerController));
    }
}
