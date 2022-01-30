using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int m_points = 0;

    public int Points
    {
        get
        {
            return m_points;
        }

        set
        {
            m_points = value;
            Debug.LogFormat("Items {0}", m_points);
        }
    }


    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
