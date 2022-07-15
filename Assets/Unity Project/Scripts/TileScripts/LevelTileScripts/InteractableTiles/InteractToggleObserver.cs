using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractToggleObserver : InteractObserver
{
    private bool m_IsToggled;

    [SerializeField]
    private UnityEvent OnToggleOn, OnToggleOff;

    // + + + + | Functions | + + + + 

    public override void OnNotify(InteractableTile sender)
    {
        if (!sender.TileIsToggle) return;

        m_IsToggled = sender.IsToggled;

        if (m_IsToggled)
        {
            OnToggleOn?.Invoke();
        }
        else
        {
            OnToggleOff?.Invoke();
        }
    }
}
