using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RtsCameraController : MonoBehaviour
{

    [SerializeField] private float m_speed;
    [SerializeField] private float m_max_zoom;
    [SerializeField] private float m_min_zoom;
    [SerializeField] private float m_sensivity_zoom;

    private Camera m_camera_;

    float x, z, w;
    private void Awake()
    {
        m_camera_ = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        w += -Input.GetAxis("Mouse ScrollWheel");

        x *= m_speed * Time.deltaTime;
        z *= m_speed * Time.deltaTime;

        transform.Translate(new Vector3(x, z, 0));
    }
    private void LateUpdate()
    {
        WheelZoom();
    }

    void WheelZoom()
    {
        if (m_min_zoom >0&& m_max_zoom >0 && m_sensivity_zoom >0)
        {
            w = Mathf.Clamp(w, m_min_zoom, m_max_zoom);
            m_camera_.fieldOfView = w * m_sensivity_zoom;
        }
    }
}
