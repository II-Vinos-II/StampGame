using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    Movements playerController;
    [SerializeField] int scoreInt;
    [SerializeField] int amount = 10;
    public bool canHavePoints;

    public void ScoreSystem()
    {
        scoreInt += amount;
    }

}
