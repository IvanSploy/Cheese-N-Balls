using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
        DOTween.Init();
        posFinal = GameObject.FindGameObjectWithTag("Queso");
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
                StartCoroutine(DoDelayedSpawn(anim.GetCurrentAnimatorStateInfo(0).length-0.1f));
                currentTime = 0;
            }
        }
    }

    IEnumerator DoDelayedSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        //Aquí se spawnea un enemigo.
        Camera.main.DOShakePosition(1, 0.2f, 10, 20);
        EnemiesManager.instance.SpawnRandomEnemy();
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
        //Quitar Vida
        if (state == BossState.NORMAL)
        {
            if (--lifeCount <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
        //Derrotar Boss
        else
        {
            PersistentData.instance.bossEliminado = true;
            //Menu Victoria
            if (Duel.instance)
                Duel.instance.WinGame();
            else
                Debug.LogWarning("Duelo requerido");
        }
    }
}
