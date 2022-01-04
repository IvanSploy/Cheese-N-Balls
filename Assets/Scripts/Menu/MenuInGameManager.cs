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
    [SerializeField] GameObject pauseButtons;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject optionsButtons;

    public Slider volumenMusica;
    public TextMeshProUGUI musicaText;

    public Slider volumenEfectos;
    public TextMeshProUGUI efectosText;


    GameObject camera;
   

    private void Awake()
    {
        pauseButtons.SetActive(false);
        
    }


    public void MusicChange()
    {
        float numVolume = volumenMusica.value * 100;
        musicaText.SetText(Mathf.RoundToInt(numVolume).ToString());
        
    }

    public void EffectsChange()
    {
        float numVolume = volumenEfectos.value * 100;
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
        
        

    }

    public void GoToPauseFromOptions()
    {
        optionsButtons.SetActive(false);
        pauseButtons.SetActive(true);
        optionsMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-1298, 0), 2);
       
    }



    public void GoToOptions()
    {
        pauseButtons.SetActive(false);
        optionsButtons.SetActive(true);
        optionsMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 2);
        
    }




}
