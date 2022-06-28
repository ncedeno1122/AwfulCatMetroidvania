using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTransform : CameraState
{
    private Transform m_TrackedTarget;
    public CameraFollowTransform(CameraStateContext ctx, Transform trackedTarget) : base(ctx)
    {
        m_TrackedTarget = trackedTarget;
    }

    public override void OnEnter()
    {
        Debug.Log("Entering CameraFollowTransform!");
    }

    public override void OnExit()
    {
        Debug.Log("Exiting CameraFollowTransform!");
    }

    public override void OnLateUpdate()
    {
        m_Context.transform.position = m_TrackedTarget.position + m_CameraOffset;
    }
}
