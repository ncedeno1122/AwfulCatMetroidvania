using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTile : LevelTileGOScript
{
    // Determines whether the tile is a button or not.
    [SerializeField]
    private bool m_TileIsToggle;
    public bool TileIsToggle { get => m_TileIsToggle; set => m_TileIsToggle = value; }

    // If the tile is a toggle
    [SerializeField]
    private bool m_IsToggled;
    public bool IsToggled { get => m_TileIsToggle; }

    // Is the Tile debounced/ready for the next interaction?
    [SerializeField]
    private bool m_IsDebounced = true;
    public bool IsDebounced { get => m_IsDebounced; }

    private const float DEBOUNCE_TIME = 0.5f;

    private IEnumerator m_DebounceCRT;

    // + + + + | Functions | + + + +

    public override void TriggerTileEffect() => HandleInteractionInput();

    public void HandleInteractionInput()
    {
        if (m_IsDebounced)
        {
            ToggleInteractableTile();
            m_DebounceCRT = DebounceCRT(DEBOUNCE_TIME);
            StartCoroutine(m_DebounceCRT);
            //Debug.Log($"InteractableTile at {transform.position} has been interacted with!");
        }
        else
        {
            //Debug.Log($"InteractableTile at {transform.position} CANNOT be interacted with!");
        }
    }

    private void ToggleInteractableTile()
    {
        if (m_TileIsToggle)
        {
            m_IsToggled = !m_IsToggled;
        }

        InvokeRequestTileInteract(transform.position, m_TileIsToggle, m_IsToggled);
    }

    private IEnumerator DebounceCRT(float debounceTime)
    {
        m_IsDebounced = false;

        yield return new WaitForSeconds(debounceTime);

        m_IsDebounced = true;
    }
}
