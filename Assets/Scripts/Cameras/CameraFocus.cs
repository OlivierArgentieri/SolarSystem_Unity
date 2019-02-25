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

    private float m_wheel_value;

    // Use this for initialization
    void Start()
    {
        InputManager.OnMouse += InputManagerOnOnMouse;
        InputManager.OnClickLeftMouseButton += InputManagerOnOnClickLeftMouseButton;
        InputManager.OnClickRightMouseButton += InputManagerOnOnClickRightMouseButton;

        m_current_planet_index_ = 0;
        m_originGameObject = m_planets[m_current_planet_index_];
        m_distance = (m_originGameObject.transform.position - transform.position).magnitude;
    }
    
    void LateUpdate()
    {
        WheelZoom();
        transform.localRotation = Quaternion.Euler(m_input_.y, m_input_.x, 0);
        transform.localPosition = m_planets[m_current_planet_index_].transform.position - (transform.localRotation * Vector3.forward * m_distance * m_wheel_value);
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
            m_wheel_value = Mathf.Clamp(m_wheel_value, m_min_zoom, m_max_zoom);
        }
    }

    
    private void InputManagerOnOnMouse(float _fxValue, float _fyValue, float _fWheelValue)
    {
        m_input_ += new Vector2(_fxValue *m_speed *Time.deltaTime, _fyValue * m_speed * Time.deltaTime);
        m_wheel_value += -_fWheelValue;
    }

    private void InputManagerOnOnClickRightMouseButton()
    {
        NextPlanet();
    }

    private void InputManagerOnOnClickLeftMouseButton()
    {
        PreviousPlanet();
    }
}