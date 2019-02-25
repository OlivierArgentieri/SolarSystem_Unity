using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCameraController : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 10;

    private Vector2 m_mouse_position_;
    private Vector2 m_input_keyboard_;
    // Use this for initialization
    void Start()
    {
        InputManager.OnMouse += InputManagerOnOnMouse;
        InputManager.OnKeyboardButtonPressed += InputManagerOnOnKeyboardButtonPressed;
    }
    
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(-m_mouse_position_.y, transform.right) * transform.rotation;
        transform.rotation = Quaternion.AngleAxis(m_mouse_position_.x, Vector3.up) * transform.rotation;
        transform.Translate(new Vector3(m_input_keyboard_.x, 0, m_input_keyboard_.y));
    }
    
    private void InputManagerOnOnMouse(float _fxValue, float _fyValue, float _fwheelvalue)
    {
        m_mouse_position_ = new Vector2(_fxValue * m_speed * Time.deltaTime, _fyValue * m_speed * Time.deltaTime);
    }

    private void InputManagerOnOnKeyboardButtonPressed(float _fhorizontalvalue, float _fverticalvalue)
    {
        m_input_keyboard_ = new Vector2(_fhorizontalvalue * m_speed * Time.deltaTime, _fverticalvalue * m_speed * Time.deltaTime);
    }

}