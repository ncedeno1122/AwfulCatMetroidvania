using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class BlessComponent : MonoBehaviour, ISkill, IResourceSkill<float>
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

    private bool m_IsComplete = true;
    public bool IsComplete => m_IsComplete;

    public ResourceType ResourceType => ResourceType.ATTINIY;

    private float m_SkillCost = 10f;
    public float SkillCost => m_SkillCost;

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
        if (!m_PlayerController.TryChangeState(new AchikBlessState(m_PlayerController, this))) return;

        // Reduce Attiniy
        m_PlayerController.AchikComponent.AttiniyComponent.DecreaseAmountBy(SkillCost, true);

        // Activate & Start CRT
        m_IsComplete = false;

        //Debug.Log("Activating Skill: BlessComponent!");
        //m_PlayerController.TryChangeState(new AchikBlessState(m_PlayerController, this));
        
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

        // Complete
        m_IsComplete = true;

        m_PlayerController.TryChangeState(new AchikGroundState(m_PlayerController));
    }

    public bool HasEnoughResource(float userResourceAmount)
    {
        return m_PlayerController.AchikComponent.AttiniyComponent.CurrAmount > userResourceAmount; // TODO: Function may be better served virtually in abstract class...
    }
}
