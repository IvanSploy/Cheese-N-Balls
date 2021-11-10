using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(HingeJoint2D))]
public class FlipperController : MonoBehaviour
{
    public bool isLeftFlipper;
    private InputMaster m_input;

    private void Awake()
    {
       m_input = new InputMaster();
       m_input.Player.Click.started += ctx => OnFlipper(ctx);
        m_input.Player.Click.canceled += ctx => OnExitFlipper();
    }

    private void OnEnable()
    {
        m_input.Enable();
    }

    private void OnDisable()
    {
        m_input.Disable();
    }

    private void OnFlipper(CallbackContext ctx)
    {
        float f = m_input.Player.ClickPosition.ReadValue<float>();
        f /= Camera.main.pixelWidth;
        Debug.Log(f);
        if (f < 0.5f)
        {
            if(isLeftFlipper) GetComponent<HingeJoint2D>().useMotor = true;
        }
        else
        {
            if (!isLeftFlipper) GetComponent<HingeJoint2D>().useMotor = true;
        }
    }
    private void OnExitFlipper()
    {
        GetComponent<HingeJoint2D>().useMotor = false;
    }
}
