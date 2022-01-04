using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Constantes
    public int BOSS_POINTS_LIMIT = 500;


    public int FLY_POINTS = 5;
    public int TOPO_POINTS = 15;
    public int RATA_POINTS = 40;
    public int BOSS_POINTS = 1000;

    //Singletone
    public static GameManager instance;

    //Editor
    public GameObject player;
    public GameObject boss;
    public Transform playerSpawn;
    public Transform bossSpawn;
    private GameObject launcherTrigger;
    

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        launcherTrigger = GameObject.Find("TriggerLauncher");
    }

    private void Start()
    {
        DoNewBall();
        InitPersistantData();
        StartCoroutine(DoWaitForBossSpawn());
    }

    public void InitPersistantData()
    {
        PersistentData data = PersistentData.instance;
        data.Points = 0;
        data.moscasDestroyed = 0;
        data.toposDestroyed = 0;
        data.ratasDestroyed = 0;
        data.bossEliminado = false;
    }

    IEnumerator DoWaitForBossSpawn()
    {
        yield return new WaitUntil(() => PersistentData.instance.Points >= BOSS_POINTS_LIMIT);
        SpawnBoss();
    }

    //Mechanics
    public void DoGameOver()
    {
        Debug.Log("Te has quedado sin vidas, fin del juego.");
    }

    public void DoNewBall(GameObject previousBall = null)
    {
        if(launcherTrigger)
            launcherTrigger.GetComponent<LauncherTrigger>().resetTrigger();
        if (previousBall) Destroy(previousBall);
        Instantiate(player, playerSpawn.position, Quaternion.identity);
    }

    //Se controla el spawneo del Boss Final.
    public void SpawnBoss()
    {
        Instantiate(boss, bossSpawn.position, Quaternion.identity);
    }
}
