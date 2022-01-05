using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour
{
    public GameObject [] posiciones = new GameObject [10];
    public RataPositions rataPositions;
    private Animator anim;
    private Collider2D collider;
    private int randomNumber;
    private bool canMove = true;
    public float speed;
    private float step;
    private Vector3 nextPos;
    private int pos;
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        collider = GetComponent<Collider2D>();
        rataPositions = FindObjectOfType<RataPositions>();
        posiciones = rataPositions.posiciones;
        pos = Random.Range(0, 2);
        nextPos = new Vector3(posiciones[pos].transform.position.x, posiciones[pos].transform.position.y + 0.6f, posiciones[pos].transform.position.z);
        SetAnimation(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canMove)
        {
            Quaternion rotTarget = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0, 0, 180) * (nextPos - this.transform.position));
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, 250f * Time.deltaTime);
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, nextPos, step);
            if(nextPos == transform.position)
            {
                canMove = false;
                StartCoroutine(TiempoAleatorio());
                SetAnimation(false);
            }
        }
        else
        {
            Quaternion rotTarget = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0, 0, 180) * (posiciones[8].transform.position - this.transform.position));
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, 250f * Time.deltaTime);
        }

    }

    //USAR ESTE METODO PARA CAMBIAR LA ANIMACION DE LA RATA.
    public void SetAnimation(bool isMoving)
    {
        if(isMoving) anim.Play("RataMoving");
        else anim.Play("Idle");
    }

    IEnumerator TiempoAleatorio()
    {
        randomNumber = Random.Range(4, 7);
        yield return new WaitForSeconds(randomNumber);
        newPos();
        if (pos != 8)
            nextPos = new Vector3(posiciones[pos].transform.position.x, posiciones[pos].transform.position.y + 0.6f, posiciones[pos].transform.position.z);
        else
            nextPos = new Vector3(posiciones[pos].transform.position.x, posiciones[pos].transform.position.y, posiciones[pos].transform.position.z);
        SetAnimation(true);
        canMove = true;
    }

    ////////////////////////////////////////////////////////// 0,1 --- 2 --- 3,4 ----5 ---- 6,7 ---- 8
    //   NECESITO SABER EL MAPA PARA PODER HACER ESTO       //
    //   SIN MORIR EN EL INTENTO. PARA SABER QUE PUNTOS     //
    //   PONER Y HACER EL ALGORITMO.                        //
    //////////////////////////////////////////////////////////

    public void newPos()
    {
        switch(pos)
        {
            case 0:
            case 1:
                pos = Random.Range(2, 5);
                break;
            case 2:
                pos = Random.Range(3, 5);
                break;
            case 3:
            case 4:
                pos = Random.Range(5, 8);
                break;
            case 5:
                pos = Random.Range(6, 8);
                break;
            case 6:
            case 7:
                pos = 8;
                break;
        }
    }
}
