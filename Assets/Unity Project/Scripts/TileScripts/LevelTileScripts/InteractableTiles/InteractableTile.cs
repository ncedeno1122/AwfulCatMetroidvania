using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    public static Tilemap m_LevelTileTilemap;

    [SerializeField]
    private List<InteractObserver> m_ObserverList = new();
    public List<InteractObserver> ObserverList { get => m_ObserverList; }

    private void OnValidate()
    {
        TryAlignToGridPosition();
    }

    private void OnTransformParentChanged()
    {
        TryAlignToGridPosition();
    }

    // + + + + | Functions | + + + +

    public override void TriggerTileEffect() => HandleInteractionInput();

    public void HandleInteractionInput()
    {
        if (m_IsDebounced)
        {
            ToggleInteractableTile();
            NotifyObservers();
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

    private void TryAlignToGridPosition()
    {
        if (!gameObject.activeInHierarchy) return;

        // Is our static Tilemap set?
        if (m_LevelTileTilemap == null) m_LevelTileTilemap = GameObject.Find("LevelTileTilemap").GetComponent<Tilemap>();

        // Are we parented to that Tilemap?
        if (transform.parent != m_LevelTileTilemap.transform)transform.SetParent(m_LevelTileTilemap.transform, true);

        // Is our position properly rounded?
        var tilemapPosition = m_LevelTileTilemap.GetCellCenterWorld(Vector3Int.RoundToInt(transform.position));
        if (transform.position != tilemapPosition) transform.position = tilemapPosition;
    }

    private void NotifyObservers()
    {
        foreach (var observer in m_ObserverList)
        {
            observer.OnNotify(this);
        }
    }
}
