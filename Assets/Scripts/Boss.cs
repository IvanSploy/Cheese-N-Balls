using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Boss : MonoBehaviour
{
    public enum BossState
    {
        NORMAL,
        WAITING,
        DUELING
    }

    private Animator anim;
    private GameObject posFinal;
    private double currentTime;
    private bool leftAttack;

    public BossState state;
    public float speed;
    [Range(0f, 10f)]
    public float spawnInterval;
    public int lifeCount = 3;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        posFinal = FindObjectOfType<DamageCheeseBehaviour>().gameObject;
        leftAttack = false;
        currentTime = spawnInterval;
    }

    private void Update()
    {
        if (state == BossState.NORMAL)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= spawnInterval)
            {
                if (leftAttack)
                {
                    leftAttack = false;
                    anim.Play("IdleRight");
                }
                else
                {
                    leftAttack = true;
                    anim.Play("IdleLeft");
                }
                StartCoroutine(DoDelayedSpawn(anim.GetCurrentAnimatorStateInfo(0).length));
                currentTime = 0;
            }
        }
    }

    IEnumerator DoDelayedSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        //Aquí se spawnea un enemigo.
        Debug.Log("Spawneando Enemigo");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (state == BossState.DUELING)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, posFinal.transform.position, step);
        }
    }

    public void SetState(BossState state)
    {
        this.state = state;
    }

    public void TakeLife()
    {
        if(--lifeCount <= 0)
        {
            //Entrar en modo duelo.
            Destroy(gameObject);
        }
    }
}
