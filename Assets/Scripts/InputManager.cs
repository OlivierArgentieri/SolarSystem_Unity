using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void MouseEventHandler(float _fxValue, float _fyValue, float _fWheelValue);
    public static event MouseEventHandler OnMouse;

    public delegate void LeftMouseButtonEventHandler();
    public static event LeftMouseButtonEventHandler OnClickLeftMouseButton;

    public delegate void RightMouseButtonEventHandler();
    public static event RightMouseButtonEventHandler OnClickRightMouseButton;

    public delegate void KeyboardButtonEventHandler(float _fHorizontalValue, float _fVerticalValue);
    public static event KeyboardButtonEventHandler OnKeyboardButtonPressed;

    public delegate void RightArrowKeyboardButtonEventHandler();
    public static event RightArrowKeyboardButtonEventHandler OnKeyboardRightArrowButtonPressed;

    public delegate void LeftArrowKeyboardButtonEventHandler();
    public static event LeftArrowKeyboardButtonEventHandler OnKeyboardLeftArrowButtonPressed;

    private void Update()
    {
        InputManager.TriggerMouseEventHandler();
        InputManager.TriggerLeftMouseButtonEventHandler();
        InputManager.TriggerRightMouseButtonEventHandler();
        InputManager.TriggerKeyboardButtonPressed();
        InputManager.TriggerKeyboardRightArrowButtonEventHandler();
        InputManager.TriggerKeyboardLeftArrowButtonEventHandler();
    }

    public static void TriggerMouseEventHandler()
    {
        if (OnMouse != null)
            OnMouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse ScrollWheel"));
    }

    public static void TriggerLeftMouseButtonEventHandler()
    {
        if (OnClickLeftMouseButton != null && Input.GetKeyDown(KeyCode.Mouse0))
            OnClickLeftMouseButton();
    }

    public static void TriggerRightMouseButtonEventHandler()
    {
        if (OnClickRightMouseButton != null && Input.GetKeyDown(KeyCode.Mouse1))
            OnClickRightMouseButton();
    }

    public static void TriggerKeyboardButtonPressed()
    {
        if (OnKeyboardButtonPressed != null)
            OnKeyboardButtonPressed(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public static void TriggerKeyboardRightArrowButtonEventHandler()
    {
        if (OnKeyboardRightArrowButtonPressed != null && Input.GetKeyDown(KeyCode.RightArrow))
            OnKeyboardRightArrowButtonPressed();
    }

    public static void TriggerKeyboardLeftArrowButtonEventHandler()
    {
        if (OnKeyboardLeftArrowButtonPressed != null && Input.GetKeyDown(KeyCode.LeftArrow))
            OnKeyboardLeftArrowButtonPressed();
    }
}
