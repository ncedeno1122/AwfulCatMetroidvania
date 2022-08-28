using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides a component-based approach to work with the Attiniy resource with a UI Slider.
/// </summary>
public class AttiniyComponent : MonoBehaviour
{
    public float MaxAmount = 100f;
    private float m_CurrAmount = 100f;
    public float CurrAmount { get => m_CurrAmount; } 
    public float AmountPercentOfMax { get => CurrAmount / MaxAmount; }

    [SerializeReference]
    private AttiniyUIController m_AttiniyUIController;
    public AttiniyUIController AttiniyUIController { get => m_AttiniyUIController; }

    private void Awake()
    {
        // TODO: Load Attiniy amount from last play session?
        m_CurrAmount = MaxAmount;
    }

    private void Start()
    {
        AttiniyUIController.UpdateSlider(CurrAmount);
    }

    // + + + + | Functions | + + + + 

    public void SetAmount(float newAmount)
    {
        AttiniyUIController.UpdateSlider(m_CurrAmount, newAmount);

        // Finally, update new value
        m_CurrAmount = newAmount;
    }

    public void IncreaseAmountBy(float delta, bool animate)
    {
        if (animate && m_CurrAmount != 100f)
        {
            AttiniyUIController.UpdateSlider(m_CurrAmount, m_CurrAmount + delta);
        }
        else
        {
            AttiniyUIController.UpdateSliderNoAnim(m_CurrAmount + delta);
        }
        m_CurrAmount = (m_CurrAmount + delta >= 100f) ? 100f : m_CurrAmount + delta;
    }

    public void DecreaseAmountBy(float delta, bool animate)
    {
        if (animate && m_CurrAmount != 0f)
        {
            AttiniyUIController.UpdateSlider(m_CurrAmount, m_CurrAmount - delta);
        }
        else
        {
            AttiniyUIController.UpdateSliderNoAnim(m_CurrAmount - delta);
        }
        m_CurrAmount = (m_CurrAmount - delta <= 0f) ? 0f : m_CurrAmount - delta;
    }
}
