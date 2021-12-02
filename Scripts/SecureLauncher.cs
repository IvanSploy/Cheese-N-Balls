using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecureLauncher : MonoBehaviour
{
    public bool hasEnter = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        hasEnter = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        hasEnter = false;
    }
}
