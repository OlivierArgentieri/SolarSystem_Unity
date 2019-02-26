using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RtsCameraController : MonoBehaviour
{

    [SerializeField] private float m_speed;
    [SerializeField] private float m_max_zoom;
    [SerializeField] private float m_min_zoom;
    [SerializeField] private float m_sensivity_zoom;
    
    private float m_wheel_value_;
    private float m_horizontal_keyboard_input_;
    private float m_vertical_keyboard_input_;

    void Start()
    {
        InputManager.m_instance.OnMouse += InputManagerOnOnMouse;
        InputManager.m_instance.OnKeyboardButtonPressed += InputManagerOnOnKeyboardButtonPressed;
    }

    private void Update()
    {
        WheelZoom();
        transform.Translate(new Vector3(m_horizontal_keyboard_input_, m_vertical_keyboard_input_, 0));
        transform.position = new Vector3(transform.position.x, m_wheel_value_ * m_sensivity_zoom, transform.position.z);
    }

    void WheelZoom()
    {
        if (m_min_zoom >0&& m_max_zoom >0 && m_sensivity_zoom >0)
        {
            m_wheel_value_ = Mathf.Clamp(m_wheel_value_, m_min_zoom, m_max_zoom);
        }
    }

    private void InputManagerOnOnMouse(float _fxValue, float _fyValue, float _fWheelValue)
    {
        m_wheel_value_ += -_fWheelValue;
    }

    private void InputManagerOnOnKeyboardButtonPressed(float _fhorizontalvalue, float _fverticalvalue)
    {
        m_horizontal_keyboard_input_ = _fhorizontalvalue * m_speed * Time.deltaTime;
        m_vertical_keyboard_input_ = _fverticalvalue * m_speed * Time.deltaTime;
    }
}