using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class LevelTileGOScript : MonoBehaviour
{
    protected bool m_AllowProjectilesThrough;
    public bool AllowProjectilesThrough { get => m_AllowProjectilesThrough; }

    // Events
    public delegate void DeleteTileAction(Vector3 worldPosition);
    public static event DeleteTileAction RequestTileDelete;

    public delegate void RestoreTileAction(Vector3 worldPosition);
    public static event RestoreTileAction RequestTileRestore;

    public delegate void InteractTileAction(Vector3 worldPosition, bool isToggled);
    public static event InteractTileAction RequestTileInteract;

    // + + + + | Functions | + + + + 

    public abstract void TriggerTileEffect();

    protected void InvokeRequestTileDelete(Vector3 worldPosition)
    {
        RequestTileDelete(worldPosition);
    }
    protected void InvokeRequestTileRestore(Vector3 worldPosition)
    {
        RequestTileRestore(worldPosition);
    }

    protected void InvokeRequestTileInteract(Vector3 worldPosition, bool isToggled)
    {
        RequestTileInteract(worldPosition, isToggled);
    }
}
