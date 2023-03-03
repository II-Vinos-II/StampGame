using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    Movements playerController;
    [SerializeField] int scoreInt;
    [SerializeField] int amount = 10;
    public bool canHavePoints;
    public TextMeshProUGUI text;

    public void ScoreSystem()
    {
        scoreInt += amount;
        text.text = ": " +  scoreInt.ToString();

    }

}
