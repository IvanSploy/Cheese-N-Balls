using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public Slider volumenMusica;
    public TextMeshProUGUI musicaText;

    public Slider volumenEfectos;
    public TextMeshProUGUI efectosText;


    GameObject camera;
   

    private void Awake()
    {
        pauseButton.SetActive(true);
        pauseButtons.SetActive(false);
        optionsButtons.SetActive(false);
        defeatButtons.SetActive(false);
        
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


    public void StopGame(bool activar)
    {
        if (activar) Time.timeScale = 0;
        else Time.timeScale = 1;
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

        pauseButton.SetActive(false);
        StopGame(true);
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
