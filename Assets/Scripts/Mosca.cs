using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosca : MonoBehaviour
{
    public GameObject posFinal;
    [Range(0f, 2f)]
    public float vibrate = 1f;
    public float speed;
    private float step;

    // Update is called once per frame
    void FixedUpdate()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, posFinal.transform.position, step);
        Vector2 vibration = new Vector3(Random.Range(-0.1f, 0.1f) * vibrate, Random.Range(-0.1f, 0.1f) * vibrate);
        transform.position = new Vector3(transform.position.x + vibration.x, transform.position.y + vibration.y, transform.position.z);
    }
}
