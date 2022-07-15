using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingDoor : MonoBehaviour
{
    [SerializeField] private bool m_IsClosed = true;
    [SerializeField] private bool m_IsMoving;
    [SerializeField] private float m_MoveTime = 2f;

    private IEnumerator m_DoorMoveCRT;
    private Rigidbody2D m_rb2d;

    private void Awake()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    // + + + + | Functions | + + + + 

    public void ToggleDoor()
    {
        Debug.Log("Toggling door!");
        if (m_IsMoving) return;

        if (m_IsClosed)
        {
            // Open!
            Debug.Log("Opening door!");
            m_DoorMoveCRT = MoveToPosition(m_rb2d.position + Vector2.up * 4, m_MoveTime);
            StartCoroutine(m_DoorMoveCRT);
            m_IsClosed = false;
        }
        else
        {
            // Close!
            Debug.Log("Closing door!");
            m_DoorMoveCRT = MoveToPosition(m_rb2d.position + Vector2.down * 4, m_MoveTime);
            StartCoroutine(m_DoorMoveCRT);
            m_IsClosed = true;
        }
    }

    private IEnumerator MoveToPosition(Vector2 targetPosition, float time)
    {
        float steps = 50;
        m_IsMoving = true;

        for (int i = 0; i < steps; i++)
        {
            m_rb2d.MovePosition(m_rb2d.position + (targetPosition - m_rb2d.position) / steps);
            yield return new WaitForSecondsRealtime(time / steps);
        }

        m_IsMoving = false;
        Debug.Log("Done with door movement!");
    }
}
