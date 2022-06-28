using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLaxFollowTransform : CameraState
{
    private float m_CameraSmoothSpeed = 10f; // TODO: Duplication from CameraFollowTransform...
    private const float CAM_MOVE_THRESHOLD_X = 0.35f;
    private const float CAM_MOVE_THRESHOLD_Y = 0.3f;
    private Transform m_TrackedTarget;

    public CameraLaxFollowTransform(CameraStateContext context, Transform trackedTarget) : base(context)
    {
        m_TrackedTarget = trackedTarget;
    }

    public override void OnEnter()
    {
        Debug.Log("Entering CameraLaxFollowTransform!");
    }

    public override void OnExit()
    {
        Debug.Log("Exiting CameraLaxFollowTransform!");
    }

    public override void OnLateUpdate()
    {
        var transformViewPortPosition = m_Context.Camera.WorldToViewportPoint(m_TrackedTarget.position);

        if ((transformViewPortPosition.x <= CAM_MOVE_THRESHOLD_X || transformViewPortPosition.x >= (1f - CAM_MOVE_THRESHOLD_X))
            || (transformViewPortPosition.y <= CAM_MOVE_THRESHOLD_Y || transformViewPortPosition.y >= (1f - CAM_MOVE_THRESHOLD_Y))
            || (m_Context.transform.position.z != m_CameraOffset.z))
        {
            m_Context.transform.position = Vector3.Lerp(m_Context.transform.position, m_TrackedTarget.position + m_CameraOffset, m_CameraSmoothSpeed * Time.deltaTime);
        }
    }
}
