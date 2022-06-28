using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraState
{
    protected Vector3 m_CameraOffset = new Vector3(0f, 0.5f, -10f);
    protected CameraStateContext m_Context;

    protected CameraState(CameraStateContext context)
    {
        m_Context = context;
    }

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnLateUpdate();
}
