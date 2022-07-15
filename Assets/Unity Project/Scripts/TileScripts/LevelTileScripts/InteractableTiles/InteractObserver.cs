using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractObserver : MonoBehaviour
{
    public abstract void OnNotify(InteractableTile sender);
}
