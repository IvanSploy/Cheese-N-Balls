using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private Camera camera;
    public SpriteRenderer background;

    // Start is called before the first frame update
    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void Start()
    {
        //Se ajusta la camara al ancho del fondo.
        Sprite fondo = background.sprite;
        float ancho = fondo.rect.width / fondo.pixelsPerUnit;
        float alto = ancho / camera.aspect;
        camera.orthographicSize = alto * 0.5f;

        //Se ajusta el juego para dejar más espacio en la parte superior.
        float altoImagen = fondo.rect.height / fondo.pixelsPerUnit;
        Vector3 pos = transform.position;
        pos.y += (alto - altoImagen) * 0.5f + background.transform.position.y;
        transform.position = pos;
    }
}
