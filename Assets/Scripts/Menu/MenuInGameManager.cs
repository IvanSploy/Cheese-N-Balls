using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using DG.Tweening;


public class MenuInGameManager : MonoBehaviour
{
    
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButtons;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject optionsButtons;
    [SerializeField] GameObject defeatMenu;
    [SerializeField] GameObject defeatButtons;

    public AudioMixer masterMixer;
    private AudioSource audioBoton;

    public Slider musicSlider;
    public TextMeshProUGUI musicaText;

    public Slider efectosSlider;
    public TextMeshProUGUI efectosText;

    [SerializeField] private AudioSource audioMuelle;
    [SerializeField] private AudioSource audioPalancaIzq;
    [SerializeField] private AudioSource audioPalancaDer;

    public AudioSource audioDerrota;
    public AudioSource audioMusica;

    GameObject camera;
   

    private void Awake()
    {
        pauseButton.SetActive(true);
        pauseButtons.SetActive(false);
        optionsButtons.SetActive(false);
        defeatButtons.SetActive(false);
        audioBoton = GetComponent<AudioSource>();
        musicSlider.value = PlayerPrefs.GetFloat("volumenSonido", -20);
        efectosSlider.value = PlayerPrefs.GetFloat("volumenEfectos", -20);
        masterMixer.SetFloat("Musica", musicSlider.value);
        masterMixer.SetFloat("Efectos", efectosSlider.value);
        MusicChange();
        EffectsChange();
      
    }


    public void MusicChange()
    {
        float numVolume = musicSlider.value;
        musicaText.SetText(Mathf.RoundToInt(numVolume).ToString());
        PlayerPrefs.SetFloat("volumenSonido", numVolume);
        masterMixer.SetFloat("Musica", numVolume);
    }

    public void PlayButtonSound()
    {
        audioBoton.Play();
    }

    public void EffectsChange()
    {
        float numVolume = efectosSlider.value;
        efectosText.SetText(Mathf.RoundToInt(numVolume).ToString());
        PlayerPrefs.SetFloat("volumenEfectos", numVolume);
        masterMixer.SetFloat("Efectos", numVolume);
    }


    public void StopGame(bool activar)
    {

        

        if (activar)
        {
            audioPalancaDer.mute = true;
            audioPalancaIzq.mute = true;
            audioMuelle.mute = true;
            Time.timeScale = 0;
        }
        else
        {
            audioPalancaDer.mute = false;
            audioPalancaIzq.mute = false;
            audioMuelle.mute = false;
            Time.timeScale = 1;
        }
    }

    [ContextMenu("Volver")]
    public void GoToGameFromPause()
    {
        pauseButtons.SetActive(false);
        pauseButton.SetActive(true);
        
        var tween = pauseMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1900, 0), 1.5f);
        tween.SetUpdate(true);
        StopGame(false);

    }

    public void GoToPauseFromOptions()
    {
        optionsButtons.SetActive(false);
        pauseButtons.SetActive(true);

        var tween =optionsMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-1900, 0), 1.5f);
        tween.SetUpdate(true);
        tween = pauseMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1.5f);
        tween.SetUpdate(true);
    }



    public void GoToOptions()
    {
        pauseButtons.SetActive(false);
        optionsButtons.SetActive(true);
        var tween = optionsMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1.5f);
        tween.SetUpdate(true);
        tween = pauseMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1900, 0), 1.5f);
        tween.SetUpdate(true);

    }

    public void GoToPause()
    {

        pauseButton.SetActive(false);
        StopGame(true);
        pauseButtons.SetActive(true);
        Debug.Log("pausa");
        optionsButtons.SetActive(false);

        var tween = pauseMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1.5f);
        tween.SetUpdate(true);
    }
    public void GoToDefeat()
    {
        audioMusica.mute = true;
        pauseButton.SetActive(false);
        StopGame(true);
        audioDerrota.Play();
        defeatButtons.SetActive(true);

        

        var tween = defeatMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1.5f);
        tween.SetUpdate(true);
    }


    public void GoToMainMenu()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }

    public void RestartGame()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Restart Scene");
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;

    }




}
