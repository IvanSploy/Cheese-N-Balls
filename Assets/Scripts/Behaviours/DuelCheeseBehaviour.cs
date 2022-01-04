using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelCheeseBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss")
        {
            //Pantalla Derrota
            if (Duel.instance)
                Duel.instance.GameOver();
            else
                Debug.LogWarning("Duelo requerido");
        }
    }
}
