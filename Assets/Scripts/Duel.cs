using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Duel : MonoBehaviour
{
    [SerializeField] private GameObject izquierda;
    [SerializeField] private GameObject derecha;
    [SerializeField] private GameObject vs;
    [SerializeField] private GameObject uno;
    [SerializeField] private GameObject dos;
    [SerializeField] private GameObject tres;

    private float offset = 0.3f;
    private Vector3 posFinalIzquierda = new Vector3(-1.20000005f,2.75927567f,-4.95151997f);
    private Vector3 posFinalDerecha = new Vector3(1.26999998f,2.75927567f,-4.95151997f);
    private Vector3 posFinalVs = new Vector3(2.4977262f, 2.4977262f, 2.4977262f);
    // Start is called before the first frame update
    void Start()
    { 
        DOTween.Init();
        DuelAnimation();
    }

    // Update is called once per frame
    void DuelAnimation()
    {
        Sequence duelAnimation = DOTween.Sequence();
        
        duelAnimation.Append(izquierda.transform.DOMoveX(posFinalIzquierda.x, 0.5f));
        duelAnimation.Join(derecha.transform.DOMoveX(posFinalDerecha.x, 0.5f));
        izquierda.transform.DOShakePosition(1f, new Vector3(0.1f, 0 , 0), 7, 0, false, false).SetDelay(0.5f);
        derecha.transform.DOShakePosition(1f, new Vector3(0.1f, 0 , 0), 7, 0, false, false).SetDelay(0.5f);
        duelAnimation.Join(vs.transform.DOScale(posFinalVs, 0.8f));
        duelAnimation.Join(vs.transform.DORotate(new Vector3(720, 0, 0), 0.9f, RotateMode.FastBeyond360));
        duelAnimation.Append(vs.transform.DOPunchScale(new Vector3 (2, 2, 2), 0.4f, 4, 1));
        duelAnimation.Append(vs.transform.DOScale(new Vector3(1.04907f,1.04907f,1.04907f), 0.4f));
        duelAnimation.Append(vs.transform.DOScale(new Vector3(200f,200f,200f), 0.2f)).OnComplete(DesactivarVS);
        duelAnimation.Join(vs.GetComponent<SpriteRenderer>().DOFade(0, 0.2f));
        duelAnimation.Join(izquierda.transform.DOMoveX(-5.3499999f, 0.5f));
        duelAnimation.Join(derecha.transform.DOMoveX(5.48000002f, 0.5f));
        duelAnimation.Append(tres.transform.DOScale(new Vector3(4f,4f,4f), 0.3f));
        duelAnimation.Join(tres.transform.DORotate(new Vector3(360, 0, 0), 0.4f, RotateMode.FastBeyond360));
        duelAnimation.Append(tres.transform.DOScale(new Vector3(300f,300f,300f), 0.3f)).SetDelay(0.4f);
        duelAnimation.Join(tres.GetComponent<SpriteRenderer>().DOFade(0, 0.3f));
        duelAnimation.Append(dos.transform.DOScale(new Vector3(4f,4f,4f), 0.3f));
        duelAnimation.Join(dos.transform.DORotate(new Vector3(360, 0, 0), 0.4f, RotateMode.FastBeyond360));
        duelAnimation.Append(dos.transform.DOScale(new Vector3(300f,300f,300f), 0.3f)).SetDelay(0.4f);
        duelAnimation.Join(dos.GetComponent<SpriteRenderer>().DOFade(0, 0.3f));
        duelAnimation.Append(uno.transform.DOScale(new Vector3(4f,4f,4f), 0.3f));
        duelAnimation.Join(uno.transform.DORotate(new Vector3(360, 0, 0), 0.4f, RotateMode.FastBeyond360));
        duelAnimation.Append(uno.transform.DOScale(new Vector3(300f,300f,300f), 0.3f)).SetDelay(0.4f);
        duelAnimation.Join(uno.GetComponent<SpriteRenderer>().DOFade(0, 0.3f)).OnComplete(DesactivarNumeros);
    }
    void DesactivarVS()
    {
        vs.GetComponent<SpriteRenderer>().enabled = false;
    }
    void DesactivarNumeros()
    {
        uno.GetComponent<SpriteRenderer>().enabled = false;
        dos.GetComponent<SpriteRenderer>().enabled = false;
        tres.GetComponent<SpriteRenderer>().enabled = false;
    }
}