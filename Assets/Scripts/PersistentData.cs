using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersistentData : MonoBehaviour
{
    public static PersistentData instance;

    //Control de juego
    private int m_points;
    public int Points
    {
        get { return m_points; }
        set
        {
            m_points = value;
            GameObject pointsObject = GameObject.FindGameObjectWithTag("Points");
            if (pointsObject)
            {
                pointsObject.GetComponent<TMP_Text>().SetText("" + m_points);
            }
        }
    }
    public int moscasDestroyed;
    public int toposDestroyed;
    public int ratasDestroyed;
    public bool bossEliminado;


    private void Awake()
    {
        if (instance) Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }
}
