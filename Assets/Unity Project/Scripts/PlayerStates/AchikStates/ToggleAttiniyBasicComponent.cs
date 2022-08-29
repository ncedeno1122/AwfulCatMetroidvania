using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Passive Ability wrapper Component, dictates whether basic attacks will use Attiniy.
/// </summary>
public class ToggleAttiniyBasicComponent : MonoBehaviour, ISkill
{
    public bool IsComplete => true;

    [SerializeField]
    private bool m_BasicAttacksUseAttiniy = false;
    public bool BasicAttacksUseAttiniy { get => m_BasicAttacksUseAttiniy; }

    public void ActivateSkill()
    {
        m_BasicAttacksUseAttiniy = !m_BasicAttacksUseAttiniy;
    }

    public void DeactivateSkill()
    {
        //
    }
}
