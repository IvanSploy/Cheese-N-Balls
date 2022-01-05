using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class MenuInDuelManager : MonoBehaviour
{

    
    [SerializeField] GameObject menuWinButton;
    [SerializeField] GameObject menuDefeatButton;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject defeatMenu;
    [SerializeField] GameObject menuButton;

    


    GameObject camera;


    private void Awake()
    {
        menuWinButton.SetActive(true);
        menuDefeatButton.SetActive(true);

    }




    public void StopGame(bool activar)
    {
        if (activar) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    [ContextMenu("Volver")]
    
    public void GoToMainMenu()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }



}
