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
        player = Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        player.transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);
        StartCoroutine(TiempoDeEspera());   
    }

    IEnumerator TiempoDeEspera()
    {
        yield return new WaitForSeconds(1);
        //GameObject newPlayer = Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.transform.localPosition = spawnPoint.transform.position;
    }
}
