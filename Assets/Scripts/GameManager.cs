using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Constantes
    public int BOSS_POINTS_LIMIT = 500;

    //Singletone
    public static GameManager instance;

    //Editor
    public GameObject player;
    public GameObject boss;
    public Transform playerSpawn;
    public Transform bossSpawn;
    private GameObject launcherTrigger;

    //Control de juego
    public int points;
    

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        launcherTrigger = GameObject.Find("TriggerLauncher");
    }

    private void Start()
    {
        DoNewBall();
        StartCoroutine(DoWaitForBossSpawn());
    }

    IEnumerator DoWaitForBossSpawn()
    {
        yield return new WaitUntil(() => points >= BOSS_POINTS_LIMIT);
        SpawnBoss();
    }

    //Mechanics
    public void DoGameOver()
    {
        Debug.Log("Te has quedado sin vidas, fin del juego.");
    }

    public void DoNewBall(GameObject previousBall = null)
    {
        launcherTrigger.GetComponent<LauncherTrigger>().resetTrigger();
        if (previousBall)
        {
            Destroy(previousBall);
        }
        Instantiate(player, playerSpawn.position, Quaternion.identity);
    }

    //Se controla el spawneo del Boss Final.
    public void SpawnBoss()
    {
        Instantiate(boss, bossSpawn.position, Quaternion.identity);
    }
}
