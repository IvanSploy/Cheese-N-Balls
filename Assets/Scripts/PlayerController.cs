using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("On Trigger");
        HealthBehaviour.instance.Health -= 1;
        if (collision.tag == "Enemy")
        {
            GameManager.instance.DoNewBall(collision.gameObject);
        }
    }
}
