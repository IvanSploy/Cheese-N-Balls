using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour
{
    public GameObject [] posiciones = new GameObject [10];
    private Collider2D collider;
    private int randomNumber;
    private bool canMove = true;
    public float speed;
    private float step;
    private Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();

        //
        // A QUE POSICION VA AL EMPEZAR (VARIAS POSIBLES) -- nextPos = posiciones[random entre algunas]
        //
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canMove)
        {
            Quaternion rotTarget = Quaternion.LookRotation(nextPos - this.transform.position);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, 250f * Time.deltaTime);
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, nextPos, step);
        }
        if(nextPos == transform.position)
        {
            StartCoroutine(TiempoAleatorio());
        }
    }
    IEnumerator TiempoAleatorio()
    {
        randomNumber = Random.Range(2, 4);
        yield return new WaitForSeconds(randomNumber);
        canMove = true;
        StartCoroutine(TiempoAleatorio());

        //
        // EL METODO DE ABAJO
        //

    }

    //////////////////////////////////////////////////////////
    //   NECESITO SABER EL MAPA PARA PODER HACER ESTO       //
    //   SIN MORIR EN EL INTENTO. PARA SABER QUE PUNTOS     //
    //   PONER Y HACER EL ALGORITMO.                        //
    //////////////////////////////////////////////////////////

    /*public int[,] newPos(int pos)
    {
        switch(pos)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                if (pos + 1 <= posiciones.GetLength(0) - 1)
                    pos = Random.Range(pos, pos + 1);
                break;
        }
        if (pos + 1 <= posiciones.GetLength(0) - 1)
            pos = Random.Range(pos, pos + 1);
        if (number - 1 < 0 && number + 1 > posiciones.GetLength(1) - 1)
            return(posiciones[pos, number].transform.position);
        else if (number - 1 < 0)
            number = Random.Range(number, number + 1);
        else if (number + 1 > posiciones.GetLength(1) - 1)
            number = Random.Range(number, number + 1);
        else
            number = Random.Range(number - 1, number + 1);
        //return([pos, number]);
    }*/
}
