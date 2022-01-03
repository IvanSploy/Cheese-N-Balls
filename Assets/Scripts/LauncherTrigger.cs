using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherTrigger : MonoBehaviour
{
    public bool close = false;
    private BoxCollider2D collider;
    
    // Start is called before the first frame update
    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        close = true;
        collider.isTrigger = false;
    }

    public void resetTrigger()
    {
        close = false;
        collider.isTrigger = true;
    }
}
