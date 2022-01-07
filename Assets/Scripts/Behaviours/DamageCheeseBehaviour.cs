using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Collider2D))]
public class DamageCheeseBehaviour : MonoBehaviour
{

    private AudioSource audioSource;
    


    private MenuInGameManager menuInGameManager;
    private Camera camera;
    void Start()
    {
        DOTween.Init();
        camera = Camera.main;
        menuInGameManager = FindObjectOfType<MenuInGameManager>();
        audioSource = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        camera.DOShakePosition(0.5f, 0.2f, 5, 20, false);
        HealthBehaviour.instance.Health -= 1;
        audioSource.Play();
        if (HealthBehaviour.instance.Health <= 0)
        {
            menuInGameManager.GoToDefeat();
        }
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
