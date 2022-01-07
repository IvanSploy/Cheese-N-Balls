using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    //Singletone
    public static HealthBehaviour instance;

    //Editor
    public Sprite fullHealth;
    public Sprite emptyHealth;
    public List<Image> hearts = new List<Image>();

    //Variables
    private int m_health;

    //Atributos
    public int Health
    {
        get { return m_health; }
        set
        {
            m_health = value;

            for (int i = 0; i < hearts.Count; i++)
            {
                if (i < m_health)
                    hearts[i].sprite = fullHealth;
                else
                    hearts[i].sprite = emptyHealth;
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (hearts.Count == 0) hearts.AddRange(GetComponentsInChildren<Image>());
        Health = hearts.Count;
    }
}
