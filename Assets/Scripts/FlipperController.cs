using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
public class FlipperController : MonoBehaviour
{
    public bool isLeftFlipper;
    private InputMaster m_input;

    private void Awake()
    {
       m_input = new InputMaster();
        if (isLeftFlipper)
        {
            m_input.Player.LeftFlipper.started += ctx => OnLeftFlipper();
            m_input.Player.LeftFlipper.canceled += ctx => OnExitLeftFlipper();
        }
        else
        {
            m_input.Player.RightFlipper.started += ctx => OnRightFlipper();
            m_input.Player.RightFlipper.canceled += ctx => OnExitRightFlipper();
        }
    }

    private void OnEnable()
    {
        m_input.Enable();
    }

    private void OnDisable()
    {
        m_input.Disable();
    }

    private void OnLeftFlipper()
    {
        GetComponent<HingeJoint2D>().useMotor = true;
    }
    private void OnExitLeftFlipper()
    {
        GetComponent<HingeJoint2D>().useMotor = false;
    }
    private void OnRightFlipper()
    {
        GetComponent<HingeJoint2D>().useMotor = true;
    }
    private void OnExitRightFlipper()
    {
        GetComponent<HingeJoint2D>().useMotor = false;
    }
}
