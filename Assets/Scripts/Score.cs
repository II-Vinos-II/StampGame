using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    Movements playerController;
    [SerializeField] int scoreInt;
    [SerializeField] int amount = 10;
    [SerializeField] int amountBaril = 100;
    public bool canHavePoints;
    public TextMeshProUGUI text;
    public void Update()
    {

        text.text = "Score : " + scoreInt.ToString();
    }
    public void ScoreSystem()
    {
        scoreInt += amount;

    }

    public void ScoreSystemBaril()
    {
        scoreInt += amountBaril;
    }

}
