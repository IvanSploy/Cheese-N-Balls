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
        Destroy(enemy.gameObject);
        if (enemy.GetComponent<Mosca>())
        {
            PersistentData.instance.Points += GameManager.instance.FLY_POINTS;
            PersistentData.instance.moscasDestroyed += 1;
        }
        else if (enemy.GetComponent<Topo>())
        {
            PersistentData.instance.Points += GameManager.instance.TOPO_POINTS;
            PersistentData.instance.toposDestroyed += 1;
        }
        else
        {
            PersistentData.instance.Points += GameManager.instance.RATA_POINTS;
            PersistentData.instance.ratasDestroyed += 1;
        }
        //Incluir particulas de muerte.
    }

    public void DamageBoss(Collider2D enemy)
    {
        enemy.GetComponent<Boss>().TakeLife();
    }
}
