using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rata rata;
    [SerializeField] private Topo topo;
    [SerializeField] private Mosca mosca;
    private Vector3 randomSpawn;
    private GameObject [] enemies = new GameObject [3];
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        enemies[0] = rata.gameObject;
        enemies[1] = topo.gameObject;
        enemies[2] = mosca.gameObject;
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds (6);
        randomSpawn = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y - 0.5f, transform.position.z);
        Instantiate(enemies[Random.Range(0, 3)], randomSpawn, Quaternion.identity);
        StartCoroutine(SpawnEnemies());
    }
}
