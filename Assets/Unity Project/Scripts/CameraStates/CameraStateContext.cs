using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateContext : MonoBehaviour
{
    private Camera m_Camera;
    public Camera Camera { get => m_Camera; private set => m_Camera = value; }
    private CameraState m_CurrentCamState;
    public Transform PlayerTransform;

    private void Awake()
    {
        m_Camera = GetComponent<Camera>();
    }

    public void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // TODO: Once we have the PlayerTransform, follow it!
        m_CurrentCamState = new CameraFollowTransform(this, PlayerTransform);
    }

    private void LateUpdate()
    {
        m_CurrentCamState.OnLateUpdate();
    }

    // + + + + | Functions | + + + +

    public void ChangeState(CameraState newState)
    {
        m_CurrentCamState.OnExit();
        m_CurrentCamState = newState;
        m_CurrentCamState.OnEnter();
    }
}
