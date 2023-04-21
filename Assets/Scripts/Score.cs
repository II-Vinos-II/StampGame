using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    Movements playerController;
    [SerializeField] int scoreInt;
    [SerializeField] int amount = 50;
    [SerializeField] int amountBaril = 100;
    [SerializeField] int amountObj = 10;
    public bool canHavePoints;
    public TextMeshProUGUI text;
    public Animator anim;
    public void Update()
    {

        text.text = "Score : " + scoreInt.ToString();
    }
    public void ScoreSystem()
    {
        scoreInt += amount;
        anim.SetTrigger("ScoreEnPlus");
    }

    public void ScoreSystemBaril()
    {
        scoreInt += amountBaril;
        anim.SetTrigger("ScoreEnPlus");
    }
    public void ScoreSystemOBJ()
    {
        scoreInt += amountObj;
        anim.SetTrigger("ScoreEnPlus");
    }

}
