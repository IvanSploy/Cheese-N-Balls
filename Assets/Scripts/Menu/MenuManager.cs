using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Audio;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int levelNum;

    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject creditsButtons;
    [SerializeField] GameObject optionsButtons;
    [SerializeField] GameObject optionsMenu;

    public AudioMixer masterMixer;
    private AudioSource audioSource;


    public Slider musicSlider;
    public TextMeshProUGUI musicaText;

    public Slider efectosSlider;
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
        musicSlider.value = PlayerPrefs.GetFloat("volumenSonido", -20);
        efectosSlider.value = PlayerPrefs.GetFloat("volumenEfectos", -20);
        masterMixer.SetFloat("Musica", musicSlider.value);
        masterMixer.SetFloat("Efectos", efectosSlider.value);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        audioSource.Play();
    }


    public void MusicChange()
    {
        float numVolume = musicSlider.value;
        musicaText.SetText(Mathf.RoundToInt(numVolume).ToString());
        PlayerPrefs.SetFloat("volumenSonido", numVolume);
        masterMixer.SetFloat("Musica", numVolume);

    }

    public void EffectsChange()
    {
        float numVolume = efectosSlider.value;
        efectosText.SetText(Mathf.RoundToInt(numVolume).ToString());
        PlayerPrefs.SetFloat("volumenEfectos", numVolume);
        masterMixer.SetFloat("Efectos", numVolume);
    }



    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetCurrentLevel(int l)
    {
        currentLevel = 1;
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
