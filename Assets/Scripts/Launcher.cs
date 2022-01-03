
using static UnityEngine.InputSystem.InputAction;
using UnityEngine;
using System.Collections;
public class Launcher : MonoBehaviour
{
    public bool isActive = false;
    public float power = 0.01f;
    public float fuerza;
    private InputMaster m_input;
    private Vector3 pos;
    private Vector3 pos2;
    private GameObject launcherTrigger;

    private void Awake()
    {
        launcherTrigger = GameObject.Find("TriggerLauncher");
        pos = transform.localScale;
        pos2 = new Vector3(transform.localScale.x, transform.localScale.y / 2f, transform.localScale.z);
        m_input = new InputMaster();
        m_input.Player.Click.started += ctx => OnLauncher(ctx);
        m_input.Player.Click.canceled += ctx => OnExitLauncher();
    }

    void Update()
    {
        if (launcherTrigger.GetComponent<LauncherTrigger>().close) return;
        if (isActive)
        {
            if(pos2.y < transform.localScale.y)
                transform.localScale =  new Vector3(transform.localScale.x, pos.y - (power/100) * 2 , transform.localScale.z);
        }
        else
        {
            if(pos.y > transform.localScale.y)
                 transform.localScale =  new Vector3(transform.localScale.x, pos2.y + (1 - (power/100) * 2) , transform.localScale.z);
        }
    }
    private void FixedUpdate()
    {
        if(launcherTrigger.GetComponent<LauncherTrigger>().close) return;
        if (isActive)
        {
            fuerza = power;
            if (power != 100f)
            {
                power += 2f;
                if (power > 100f)
                    power = 100;
            }
                
        }
        else
        {
            if (power != 0.01f)
            {
                power -= 20f;
                if (power < 0)
                    power = 0.01f;
            }
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //if (collision.gameObject.name )
        if (!isActive && fuerza != 100) collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * fuerza * 0.8f);
        else if (!isActive) collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * fuerza * 1f);
    
    }
    private void OnEnable()
    {
        m_input.Enable();
    }

    private void OnDisable()
    {
        m_input.Disable();
    }
    private void OnLauncher(CallbackContext ctx)
    {
        isActive = true;
    }
    private void OnExitLauncher()
    {
        isActive = false;
    }
}
