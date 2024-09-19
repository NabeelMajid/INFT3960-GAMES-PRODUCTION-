using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifecount : MonoBehaviour
{
    public static Lifecount instance;
    public Image[] lives;
    public int remaining =4;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void LoseLife()
    {
        remaining--;
        lives[remaining].enabled = false;
        if (remaining == 0)
        {
            Debug.Log("game over");
        }
    }
    

    
}
