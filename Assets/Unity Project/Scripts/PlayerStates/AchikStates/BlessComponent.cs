using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessComponent : MonoBehaviour
{
    public const float BLESSING_TIME = 0.5f;

    [SerializeField] private Vector2 m_InitialScale;
    [SerializeField] private Vector2 m_FinalScale = new Vector2(2f, 2.25f);

    public BlessColliderScript m_BlessColliderScript;
    private Transform m_BlessTf;

    private void Awake()
    {
        if (!m_BlessColliderScript) return;
        m_BlessTf = m_BlessColliderScript.transform;
        m_InitialScale = m_BlessTf.localScale;
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
            m_BlessTf.localScale = Vector2.Lerp(m_InitialScale, m_FinalScale, currTime / BLESSING_TIME);
            yield return new WaitForFixedUpdate();
        }

        DeactivateSkill();
    }

    public void ActivateSkill()
    {
        // Activate & Start CRT
        Debug.Log("Activating Skill: BlessComponent!");
        m_BlessColliderScript.gameObject.SetActive(true);
        if ((Vector2)m_BlessTf.localScale != m_InitialScale) m_BlessTf.localScale = m_InitialScale;

        StartCoroutine(BlessCRT());
    }

    public void DeactivateSkill()
    {
        // Deactivate and rescale
        Debug.Log("Deactivating Skill: BlessComponent!");

        m_BlessTf.localScale = m_InitialScale;
        m_BlessColliderScript.gameObject.SetActive(false);
    }
}
