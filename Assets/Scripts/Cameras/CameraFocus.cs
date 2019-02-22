using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{

    [SerializeField]
    protected float m_speed;

    [SerializeField]
    protected float m_distance;

    [SerializeField]
    private List<GameObject> m_planets;

    private int m_current_planet_index_;
    private GameObject m_originGameObject;
    
    private Vector2 m_input_;
    [SerializeField] private float m_min_zoom;
    [SerializeField] private float m_max_zoom;
    [SerializeField] private float m_sensivity_zoom;
    

    private float w;
    private Camera m_camera_;

    // Use this for initialization
    void Start()
    {
        m_current_planet_index_ = 0;
        m_originGameObject = m_planets[m_current_planet_index_];
        m_distance = (m_originGameObject.transform.position - transform.position).magnitude;
        // m_distance += m_originGameObject.transform.localScale.x;
        m_camera_ = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        w += Input.GetAxis("Mouse ScrollWheel") * -1;
        m_input_ += new Vector2(Input.GetAxis("Mouse X") * m_speed * Time.deltaTime, Input.GetAxis("Mouse Y") * m_speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            PreviousPlanet();

        if (Input.GetKeyDown(KeyCode.Mouse1))
            NextPlanet();
    }

    private void LateUpdate()
    {
        WheelZoom();
        transform.localRotation = Quaternion.Euler(m_input_.y, m_input_.x, 0);
        transform.localPosition = m_planets[m_current_planet_index_].transform.position - (transform.localRotation * Vector3.forward * m_distance * w);
    }

    void NextPlanet()
    {
        if (m_current_planet_index_ < m_planets.Count - 1)
        {
            m_current_planet_index_++;
        }
        else
            m_current_planet_index_ = 0;

        m_originGameObject = m_planets[m_current_planet_index_];
    }

    void PreviousPlanet()
    {
        if (m_current_planet_index_ - 1 >= 0)
        {
            m_current_planet_index_--;
        }
        else
            m_current_planet_index_ = m_planets.Count - 1;
        m_originGameObject = m_planets[m_current_planet_index_];
    }

    void WheelZoom()
    {
        if (m_min_zoom > 0 && m_max_zoom > 0 && m_sensivity_zoom > 0)
        {
            w = Mathf.Clamp(w, m_min_zoom, m_max_zoom);
        }
    }   
}