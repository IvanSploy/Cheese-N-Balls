using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    private MenuManager menuManager;

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }

     private void OnTriggerEnter2D(Collider2D collider2D)
     {
         Debug.Log("eh");
         menuManager.LoadLevel();
     }
}
