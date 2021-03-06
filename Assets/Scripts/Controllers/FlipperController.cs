using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(HingeJoint2D))]
[RequireComponent(typeof(AudioSource))]
public class FlipperController : MonoBehaviour
{
    public bool isActive = true;
    public bool isLeftFlipper;
    private InputMaster m_input;
    private GameObject launcherTrigger;
    private AudioSource audioSource;

    private void Awake()
    {
        launcherTrigger = GameObject.Find("TriggerLauncher");
        m_input = new InputMaster();
        m_input.Player.Click.started += ctx => OnFlipper(ctx);
        m_input.Player.Click.canceled += ctx => OnExitFlipper();
        audioSource = GetComponent<AudioSource>();
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
        if(!isActive) return;
        Debug.Log("Flipper");
        if(launcherTrigger)
            if(!launcherTrigger.GetComponent<LauncherTrigger>().close) return;
        float f = m_input.Player.ClickPosition.ReadValue<float>();
        f /= Camera.main.pixelWidth;

        audioSource.Play();

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
