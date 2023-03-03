using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    Movements playerController;
    public float life = 3;

    public void LifeCounter()
    {
        life--;
        if(life == 0)
        {
            print("game over");
        }
    }
}
