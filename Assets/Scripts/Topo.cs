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
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cX = transform.position.x;
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
        randomNumber = Random.Range(2, 4);
        yield return new WaitForSeconds(randomNumber);
        topoDescubierto = !topoDescubierto;
        if (topoDescubierto)
        {
            collider.enabled = true;
            spriteRenderer.sprite = imageList[0];
        }
        else
        {
            collider.enabled = false;
            spriteRenderer.sprite = imageList[1];
        }
        StartCoroutine(TiempoAleatorio());
    }
}
