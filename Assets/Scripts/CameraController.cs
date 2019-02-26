using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CameraController : MonoBehaviour
{
    [SerializeField] private List<Camera> m_cameras;

    private int m_current_index_camera_;
    // Use this for initialization
    void Start()
    {
        InputManager.OnKeyboardRightArrowButtonPressed += InputManagerOnOnKeyboardRightArrowButtonPressed;
        InputManager.OnKeyboardLeftArrowButtonPressed += InputManagerOnOnKeyboardLeftArrowButtonPressed;
        m_cameras.ForEach(c => c.enabled = false);
        m_cameras[0].enabled = true;
    }

    
    // Update is called once per frame
    void Update()
    {
    }


    void NextCamera()
    {
        m_cameras[m_current_index_camera_].enabled = false;
        if (m_current_index_camera_ < m_cameras.Count-1)
        {
            m_current_index_camera_++;
        }
        else
            m_current_index_camera_ = 0;

        m_cameras[m_current_index_camera_].enabled = true;
    }

    void PreviousCamera()
    {
        m_cameras[m_current_index_camera_].enabled = false;
        if (m_current_index_camera_ - 1 >=0 )
        {
            m_current_index_camera_--;
        }
        else
            m_current_index_camera_ = m_cameras.Count-1;


        m_cameras[m_current_index_camera_].enabled = true;
    }

    private void InputManagerOnOnKeyboardLeftArrowButtonPressed()
    {
        PreviousCamera();
    }

    private void InputManagerOnOnKeyboardRightArrowButtonPressed()
    {
        NextCamera();
    }
}