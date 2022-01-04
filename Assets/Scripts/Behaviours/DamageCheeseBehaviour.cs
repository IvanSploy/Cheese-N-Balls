using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Collider2D))]
public class DamageCheeseBehaviour : MonoBehaviour
{
    private Camera camera;
    void Start()
    {
        DOTween.Init();
        camera = FindObjectOfType<Camera>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        camera.DOShakePosition(1, 0.2f, 10, 20, false);
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
