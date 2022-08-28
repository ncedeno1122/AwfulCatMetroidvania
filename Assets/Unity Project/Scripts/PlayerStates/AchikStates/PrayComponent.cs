using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PrayComponent : MonoBehaviour, ISkill
{
    private bool m_IsComplete = true;
    public bool IsComplete => m_IsComplete;

    private PlayerController m_PlayerController;

    private void Awake()
    {
        m_PlayerController = GetComponent<PlayerController>();
    }

    // + + + + | Functions | + + + + 

    public void ActivateSkill()
    {
        if (!m_PlayerController.TryChangeState(new PrayState(m_PlayerController, this))) return;

        m_IsComplete = false;
    }

    public void DeactivateSkill()
    {
        m_IsComplete = true;

        m_PlayerController.TryChangeState(new AchikGroundState(m_PlayerController));
    }
}
