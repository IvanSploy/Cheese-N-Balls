using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int levelNum;

    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject creditsButtons;
    [SerializeField] GameObject optionsButtons;
    [SerializeField] GameObject optionsMenu;

    public Slider volumenMusica;
    public TextMeshProUGUI musicaText;

    public Slider volumenEfectos;
    public TextMeshProUGUI efectosText;


    GameObject camera;
    Rigidbody2D rigid;
    FlipperController[] flippers;

    private void Awake()
    {
        optionsButtons.SetActive(false);
        creditsButtons.SetActive(false);
        camera = FindObjectOfType<Camera>().gameObject;
        flippers = FindObjectsOfType<FlipperController>();
    }


    public void MusicChange()
    {
        float numVolume = volumenMusica.value;
        musicaText.SetText(Mathf.RoundToInt(numVolume).ToString());
        
    }

    public void EffectsChange()
    {
        float numVolume = volumenEfectos.value;
        efectosText.SetText(Mathf.RoundToInt(numVolume).ToString());
    }



    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetCurrentLevel(int l)
    {
        currentLevel = l;
    }

    public void IncreaseLevel()
    {
        if (currentLevel == levelNum - 1)
        {
            currentLevel = 0;
        }
        else
        {
            currentLevel++;
        }
    }

    public void DecreaseLevel()
    {
        if (currentLevel == 0)
        {
            currentLevel = levelNum - 1;
        }
        else
        {
            currentLevel--;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }


    public void GoToCredits()
    {
        menuButtons.SetActive(false);
        creditsButtons.SetActive(true);
        camera.transform.DOMoveY(5.6f, 2);
        DisableFlippers(false);
    }

    public void DisableFlippers(bool activar)
    {
        rigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        SpriteRenderer renderBola = rigid.GetComponentInChildren<SpriteRenderer>();
        var color = renderBola.color;
        if (activar)
        {
            rigid.gravityScale = 1f;
            color.a = 1f;
            renderBola.color = color;

        }
        else
        {
            rigid.gravityScale = 0f;
            rigid.velocity = new Vector2(0f, 0f);
            color.a = 0.4f;
            renderBola.color = color;
        }

        for (int i = 0; i < flippers.Length; i++)
            flippers[i].isActive = activar;
    }

    [ContextMenu("Volver")]
    public void GoToLevelSelectorFromCredits()
    {
        creditsButtons.SetActive(false);
        menuButtons.SetActive(true);
        camera.transform.DOMoveY(0, 2);
        DisableFlippers(true);

    }

    public void GoToLevelSelectorFromOptions()
    {
        optionsButtons.SetActive(false);
        menuButtons.SetActive(true);
        optionsMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-1298, 0), 2);
        DisableFlippers(true);
    }



    public void GoToOptions()
    {
        menuButtons.SetActive(false);
        optionsButtons.SetActive(true);
        optionsMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 2);
        DisableFlippers(false);
    }




}
