using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionListener : MonoBehaviour
{
    public Vector3 ListenToTilePosition;
    public UnityEvent OnInteraction;
    public static List<InteractionListener> InteractionListeners;

    private void Start()
    {
        LevelTileGOScript.RequestTileInteract += HandleInteractionEvent;
    }

    private void OnDisable()
    {
        LevelTileGOScript.RequestTileInteract -= HandleInteractionEvent;
    }

    // + + + + | Functions | + + + +

    protected virtual void HandleInteractionEvent(Vector3 worldPosition, bool isAToggle, bool isToggled)
    {
        if (worldPosition == ListenToTilePosition)
        {
            OnInteraction?.Invoke();
        }
    }
}
