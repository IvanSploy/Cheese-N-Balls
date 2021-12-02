using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class DamageCheeseBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("On Trigger");
        HealthBehaviour.instance.Health -= 1;
        if (collision.tag == "Player")
        {
            GameManager.instance.DoNewBall(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
