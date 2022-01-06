using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BoosterController : MonoBehaviour
{
    public float impulse;
    public int points = 10;
    public AudioMixer mixer;
    private AudioSource audioSource;
    private Collider2D col;


    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D otherCol)
    {
        Rigidbody2D rb = otherCol.rigidbody;
        if (!rb) return;
        ContactPoint2D puntoColision = otherCol.contacts[0];
        rb.velocity = new Vector2();
        rb.AddForce(puntoColision.normal * impulse);
        audioSource.Play();
        if (PersistentData.instance) PersistentData.instance.Points += points;
    }
}
