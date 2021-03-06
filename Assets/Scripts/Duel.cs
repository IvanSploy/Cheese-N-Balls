using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class Duel : MonoBehaviour
{
    public static Duel instance;
    public int BOSS_POINTS = 1000;
    private LauncherTrigger trigger;

    [SerializeField] private GameObject izquierda;
    [SerializeField] private GameObject derecha;
    [SerializeField] private GameObject vs;
    [SerializeField] private GameObject uno;
    [SerializeField] private GameObject dos;
    [SerializeField] private GameObject tres;

    [SerializeField] private AudioSource musicaDuelo;
    [SerializeField] private AudioSource musicaDefeat;
    [SerializeField] private AudioSource musicaWin;

    [SerializeField] GameObject menuWinButton;
    [SerializeField] GameObject menuDefeatButton;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject defeatMenu;

    public TMP_Text vidasGanar;
    public TMP_Text enemigosGanar;
    public TMP_Text puntosGanar;
    public TMP_Text vidasPerder;
    public TMP_Text enemigosPerder;
    public TMP_Text puntosPerder;

    private float offset = 0.3f;
    private Vector3 posFinalIzquierda = new Vector3(-1.20000005f,2.75927567f,-4.95151997f);
    private Vector3 posFinalDerecha = new Vector3(1.26999998f,2.75927567f,-4.95151997f);
    private Vector3 posFinalVs = new Vector3(2.4977262f, 2.4977262f, 2.4977262f);

    private void Awake()
    {
        instance = this;
        menuWinButton.SetActive(true);
        menuDefeatButton.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        trigger = FindObjectOfType<LauncherTrigger>();
        trigger.close = true;
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

        musicaDuelo.Play();
        duelAnimation.Append(vs.transform.DOScale(new Vector3(1.04907f,1.04907f,1.04907f), 0.4f));
        duelAnimation.Append(vs.transform.DOScale(new Vector3(200f,200f,200f), 0.2f)).OnComplete(DesactivarVS);
        duelAnimation.Join(vs.GetComponent<SpriteRenderer>().DOFade(0, 0.2f));
        duelAnimation.Join(izquierda.transform.DOMoveX(-5.3499999f, 0.5f));
        duelAnimation.Join(derecha.transform.DOMoveX(5.48000002f, 0.5f));
        duelAnimation.Append(tres.transform.DOScale(new Vector3(4f,4f,4f), 0.3f));
        duelAnimation.Join(tres.transform.DORotate(new Vector3(360, 0, 0), 0.4f, RotateMode.FastBeyond360));
        duelAnimation.Append(tres.transform.DOPunchScale(new Vector3 (4f, 4f, 4f),0.4f));
        duelAnimation.Append(tres.transform.DOScale(new Vector3(300f,300f,300f), 0.3f));
        duelAnimation.Join(tres.GetComponent<SpriteRenderer>().DOFade(0, 0.3f));
        duelAnimation.Append(dos.transform.DOScale(new Vector3(4f,4f,4f), 0.3f));
        duelAnimation.Join(dos.transform.DORotate(new Vector3(360, 0, 0), 0.4f, RotateMode.FastBeyond360));
        duelAnimation.Append(dos.transform.DOPunchScale(new Vector3 (4f, 4f, 4f),0.4f));
        duelAnimation.Append(dos.transform.DOScale(new Vector3(300f,300f,300f), 0.3f));
        duelAnimation.Join(dos.GetComponent<SpriteRenderer>().DOFade(0, 0.3f));
        duelAnimation.Append(uno.transform.DOScale(new Vector3(4f,4f,4f), 0.3f));
        duelAnimation.Join(uno.transform.DORotate(new Vector3(360, 0, 0), 0.4f, RotateMode.FastBeyond360));
        duelAnimation.Append(uno.transform.DOPunchScale(new Vector3 (4f, 4f, 4f),0.4f));
        duelAnimation.Append(uno.transform.DOScale(new Vector3(300f,300f,300f), 0.3f));
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
        FindObjectOfType<Boss>().state = Boss.BossState.DUELING;
        trigger.close = false;
    }

    public void WinGame()
    {
        Debug.Log("Partida ganada");
        musicaDuelo.mute = true;
        musicaWin.Play();
        
        StopGame(true);
        var tween = winMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1.5f);
        tween.SetUpdate(true);

        Destroy(FindObjectOfType<PlayerController>().gameObject);
        Destroy(FindObjectOfType<Boss>().gameObject);

        vidasGanar.SetText("" + PersistentData.instance.vida);
        enemigosGanar.SetText("" + PersistentData.instance.enemiesDestroyed);
        puntosGanar.SetText("" + PersistentData.instance.Points);
    }

    public void GameOver()
    {  
        Debug.Log("Partida perdida");
        musicaDuelo.mute = true;
        musicaDefeat.Play();

        StopGame(true);
        var tween = defeatMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 100), 1.5f);
        tween.SetUpdate(true);

        Destroy(FindObjectOfType<PlayerController>().gameObject);
        Destroy(FindObjectOfType<Boss>().gameObject);

        vidasPerder.SetText("" + PersistentData.instance.vida);
        enemigosPerder.SetText("" + PersistentData.instance.enemiesDestroyed);
        puntosPerder.SetText("" + PersistentData.instance.Points);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void StopGame(bool activar)
    {
        if (activar) Time.timeScale = 0;
        else Time.timeScale = 1;
    }


}