using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private GameObject player;
    
    void Start()
    {
        GameObject newPlayer = Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        newPlayer.transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        StartCoroutine(TiempoDeEspera());   
    }

    IEnumerator TiempoDeEspera()
    {
        yield return new WaitForSeconds(1);
        GameObject newPlayer = Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        newPlayer.transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }
}
