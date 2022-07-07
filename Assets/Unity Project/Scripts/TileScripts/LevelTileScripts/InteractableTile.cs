using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTile : LevelTileGOScript
{
    // Determines whether the tile is a button or not.
    private bool m_TileIsToggle;
    public bool TileIsToggle { get => m_TileIsToggle; set => m_TileIsToggle = value; }
    // If the tile is a toggle
    private bool m_IsToggled;
    public bool IsToggled { get => m_TileIsToggle; }

    // + + + + | Functions | + + + +

    public override void TriggerTileEffect() => ToggleInteractableTile();

    private void ToggleInteractableTile()
    {
        if (TileIsToggle)
        {
            m_IsToggled = !IsToggled;
        }

        InvokeRequestTileInteract(transform.position, TileIsToggle, IsToggled);
    }
}
