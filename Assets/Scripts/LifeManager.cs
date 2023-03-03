using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeManager : MonoBehaviour
{
    Movements playerController;
    public float life = 3;
    public GameObject gameOver;

    public TextMeshProUGUI text;
    public void LifeCounter()
    {
        life--;
        if(life == 0)
        {
            print(life);
            gameOver.SetActive(true);
        }

        text.text = ": " +  life.ToString();

    }
}
