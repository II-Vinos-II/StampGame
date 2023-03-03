using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    Movements playerController;
    public float life = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LifeCounter()
    {
        life--;
        if(life == 0)
        {
            print("game over");
        }
    }
}
