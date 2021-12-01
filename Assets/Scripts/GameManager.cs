using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singletone
    public static GameManager instance;

    //Editor
    public GameObject player;
    public Transform playerSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DoNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Mechanics
    public void DoGameOver()
    {
        Debug.Log("Te has quedado sin vidas, fin del juego.");
    }

    public void DoNewBall(GameObject previousBall = null)
    {
        if (previousBall) Destroy(previousBall);
        Instantiate(player, playerSpawn.position, Quaternion.identity);
    }
}
