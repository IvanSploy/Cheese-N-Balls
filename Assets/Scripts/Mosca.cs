using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Mosca : MonoBehaviour
{
    public GameObject posFinal;
    [Range(0f, 2f)]
    public float vibrate = 1f;
    public float speed;
    private float step;

    void Start()
    {
        posFinal = FindObjectOfType<DamageCheeseBehaviour>().gameObject;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        step = speed * Time.deltaTime;
        Vector3 movement = Vector3.MoveTowards(transform.position, posFinal.transform.position, step);
        movement.z = transform.position.z;
        Vector3 vibration = new Vector3(Random.Range(-0.1f, 0.1f) * vibrate, Random.Range(-0.1f, 0.1f) * vibrate);
        transform.position = movement + vibration;
    }
}
