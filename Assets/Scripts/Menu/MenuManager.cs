using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private int levelNum;

    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject creditsButtons;
    [SerializeField] GameObject optionsButtons;
    [SerializeField] GameObject optionsMenu;



    GameObject camera;

    private void Awake()
    {
        optionsButtons.SetActive(false);
        creditsButtons.SetActive(false);
        camera = FindObjectOfType<Camera>().gameObject;
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
        camera.transform.DOMoveY(5, 2);
    }





    [ContextMenu("Volver")]
    public void GoToLevelSelectorFromCredits()
    {
        creditsButtons.SetActive(false);
        menuButtons.SetActive(true);
        camera.transform.DOMoveY(0, 2);

    }

    public void GoToLevelSelectorFromOptions()
    {
        optionsButtons.SetActive(false);
        menuButtons.SetActive(true);
        optionsMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-1298, 0), 2);

    }



    public void GoToOptions()
    {
        menuButtons.SetActive(false);
        optionsButtons.SetActive(true);
        optionsMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 2);
    }




}
