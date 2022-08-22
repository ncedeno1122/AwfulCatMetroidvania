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
}