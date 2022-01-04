using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance;

    // Start is called before the first frame update
    [SerializeField] private Rata rata;
    [SerializeField] private Topo topo;
    [SerializeField] private Mosca mosca;
    private Vector3 randomSpawn;
    private GameObject [] enemies = new GameObject [3];

    public bool manualSpawn;
    public float interval = 6;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        enemies[0] = rata.gameObject;
        enemies[1] = topo.gameObject;
        enemies[2] = mosca.gameObject;
        ActiveAutoSpawn();
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(interval);
        while (!manualSpawn)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(interval);
        }
    }

    public void SpawnRandomEnemy()
    {
        manualSpawn = true;
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        randomSpawn = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y - 0.5f, transform.position.z);
        Instantiate(enemies[Random.Range(0, 3)], randomSpawn, Quaternion.identity);
    }

    public void ActiveAutoSpawn()
    {
        manualSpawn = false;
        StartCoroutine(SpawnEnemies());
    }
}
