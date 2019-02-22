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

    }

    // Update is called once per frame
    void Update()
    {
        m_mouse_position_ = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        m_input_keyboard_ = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        m_mouse_position_.y *= m_speed * Time.deltaTime;
        m_mouse_position_.x *= m_speed * Time.deltaTime;
        m_input_keyboard_.x *= m_speed * Time.deltaTime;
        m_input_keyboard_.y *= m_speed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.AngleAxis(-m_mouse_position_.y, transform.right) * transform.rotation;
        transform.rotation = Quaternion.AngleAxis(m_mouse_position_.x, Vector3.up) * transform.rotation;
        transform.Translate(new Vector3(m_input_keyboard_.x, 0, m_input_keyboard_.y));
    }
}