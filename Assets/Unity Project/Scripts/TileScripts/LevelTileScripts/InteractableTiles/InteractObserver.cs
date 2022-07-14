using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractObserver : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnInteraction;

    // + + + + | Functions | + + + +

    public void OnNotify(InteractableTile subject)
    {
        Debug.Log($"{gameObject.name} was notified by {subject.name}!");

        if (OnInteraction != null) OnInteraction.Invoke();
    }
}
