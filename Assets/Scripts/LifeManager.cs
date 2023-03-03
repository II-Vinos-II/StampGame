using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    Movements playerController;
    public float life = 3;
    public GameObject gameOver;
    public void LifeCounter()
    {
        life--;
        if(life == 0)
        {
            print(life);
            gameOver.SetActive(true);
            playerController.speed = 0;
        }
    }
}
