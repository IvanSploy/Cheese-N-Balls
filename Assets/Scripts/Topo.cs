using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topo : MonoBehaviour
{
    public Sprite[] imageList = new Sprite[2];
    public GameObject posFinal;
    private float cX, contador, xSen, step;
    public float anchoCiclo, frecuencia, speed, offset;
    private bool topoDescubierto;
    private int randomNumber;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider;

    private Animator anim;

    private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cX = transform.position.x;
        particleSystem = GetComponentInChildren<ParticleSystem>();

        StartCoroutine(TiempoAleatorio());
    }

    void FixedUpdate()
    {
        if(!topoDescubierto)
        {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, posFinal.transform.position, step);
            contador = contador + (frecuencia/100);
            xSen = Mathf.Sin(contador + offset);
            transform.position = new Vector3(cX + (xSen * anchoCiclo), transform.position.y, transform.position.z);
        }
    }

    IEnumerator TiempoAleatorio()
    {
        if (topoDescubierto)
            randomNumber = Random.Range(4, 8);
        else
            randomNumber = Random.Range(2, 4);

        yield return new WaitForSeconds(randomNumber);

        topoDescubierto = !topoDescubierto;
        if (topoDescubierto)
        {
            
            particleSystem.Stop();
            anim.Play("goOutAnim");
            yield return new WaitForSeconds(0.4f);
            anim.Play("idleAnim");
            

            collider.enabled = true;
        }
        else
        {
            anim.Play("goInAnim");
            yield return new WaitForSeconds(0.4f);
            anim.Play("underground");
            
            particleSystem.Play();

            collider.enabled = false;
        }
        StartCoroutine(TiempoAleatorio());
    }
}
