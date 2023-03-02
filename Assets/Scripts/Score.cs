using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    Movements playerController;
    [SerializeField] int scoreInt;
    [SerializeField] int scoreAdded = 10;
    public bool canHavePoints;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ScoreSystem()
    {
        scoreInt++;
    }

}
