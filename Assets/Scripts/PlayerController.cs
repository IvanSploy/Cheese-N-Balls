using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Range(0,1)]
    float deltaIdle = 0.01f;

    private Rigidbody2D rigidbody;
    private Animator anim;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponentInParent<Animator>();
    }

    private void LateUpdate()
    {
        float velocity = rigidbody.velocity.x;
        if (velocity == 0) return;
        if(velocity > deltaIdle)
            anim.Play("MovingRight");
        else if (velocity > 0)
            anim.Play("IdleRight");
        else if (velocity >= -deltaIdle)
            anim.Play("IdleLeft");
        else
            anim.Play("MovingLeft");
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            DamageEnemy(collision);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            DamageEnemy(collision.collider);
        }
        if (collision.collider.tag == "Boss")
        {
            DamageBoss(collision.collider);
        }
    }

    public void DamageEnemy(Collider2D enemy)
    {
        enemy.GetComponent<AudioSource>().Play();

        Debug.Log("Muerte bicho");
        if (enemy.GetComponent<Mosca>())
        {
            PersistentData.instance.Points += GameManager.instance.FLY_POINTS;
            PersistentData.instance.enemiesDestroyed += 1;
        }
        else if (enemy.GetComponent<Topo>())
        {
            PersistentData.instance.Points += GameManager.instance.TOPO_POINTS;
            PersistentData.instance.enemiesDestroyed += 1;
        }
        else
        {
            PersistentData.instance.Points += GameManager.instance.RATA_POINTS;
            PersistentData.instance.enemiesDestroyed += 1;
        }
        StartCoroutine(KillEnemy(enemy.gameObject));
        //Incluir particulas de muerte.
    }

    IEnumerator KillEnemy(GameObject enemy)
    {
        foreach (var collider in enemy.GetComponentsInChildren<Collider2D>())
        {
            collider.enabled = false;
        }
        foreach (var renderer in enemy.GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }
        yield return new WaitForSeconds(2);
        Destroy(enemy);
    }

    public void DamageBoss(Collider2D enemy)
    {
        enemy.GetComponent<Boss>().TakeLife();
    }
}
