using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public ScreenManager screenManager;
    Movements playerController;
    public float life = 3;

    public TextMeshProUGUI text;

    private void Update()
    {

        text.text = ": " + life.ToString();
    }
    public void LifeCounter()
    {
        life--;
        if(life == 0)
        {
            print(life);
            screenManager.gameOvered = true;
        }


    }
}
