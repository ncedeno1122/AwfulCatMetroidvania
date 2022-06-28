using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ParallaxTilemap : MonoBehaviour
{
    [Range(1f, 10f)]
    public float m_ParallaxRateX = 5f;
    [Range(1f, 10f)]
    public float m_ParallaxRateY = 3.5f;

    private Vector3 m_TilemapPosition;
    private Tilemap m_Tilemap;
    public Camera m_MainCamera;

    private void Awake()
    {
        m_TilemapPosition = transform.position;

        m_Tilemap = GetComponent<Tilemap>();
    }

    private void Start()
    {
        m_MainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(m_TilemapPosition.x + (m_MainCamera.transform.position.x * (1 / m_ParallaxRateX)),
                                         m_TilemapPosition.y + (m_MainCamera.transform.position.y * (1 / m_ParallaxRateY)),
                                         0f);
    }
}
