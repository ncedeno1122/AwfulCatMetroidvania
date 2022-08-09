using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlessInteractionHandler : MonoBehaviour
{
    public UnityEvent OnBless;

    // + + + + | Functions | + + + + 

    public void HandleBless()
    {
        Debug.Log($"Received Blessing in {gameObject.name}!");
        OnBless?.Invoke();
    }
}
