using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractNontoggleObserver : InteractObserver
{
    [SerializeField]
    private UnityEvent OnNontoggle;

    // + + + + | Functions | + + + + 

    public override void OnNotify(InteractableTile sender)
    {
        OnNontoggle?.Invoke();
    }

}
