using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    Movements playerController;
    [SerializeField] int scoreInt;
    [SerializeField] int scoreAdded = 10;
    [SerializeField] int nbPorteCasséesForCombo;
    [SerializeField] int combo;
    public bool combo2 = false;
    public bool combo3 = false;
    public bool combo4 = false;
    public bool combo5 = false;
    public bool combo6 = false;
    public bool combo7 = false;
    public bool combo8 = false;
    public bool scoreEnPlus;

    public int Scoring { get; private set; }
    public int ComboPoints { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (nbPorteCasséesForCombo > 4 && nbPorteCasséesForCombo <= 9)
        {
            IncreaseCombo();
        }
        if (nbPorteCasséesForCombo > 9 && nbPorteCasséesForCombo <= 14)
        {
            IncreaseCombo();
        }
        if (nbPorteCasséesForCombo > 14 && nbPorteCasséesForCombo <= 19)
        {
            IncreaseCombo();
        }
        if (nbPorteCasséesForCombo > 19 && nbPorteCasséesForCombo <= 24)
        {
            IncreaseCombo();
        }
        if (nbPorteCasséesForCombo > 24 && nbPorteCasséesForCombo <= 29)
        {
            IncreaseCombo();
        }
        if (nbPorteCasséesForCombo > 29 && nbPorteCasséesForCombo <= 34)
        {
            IncreaseCombo();
        }
        if (nbPorteCasséesForCombo > 34 && nbPorteCasséesForCombo <= 39)
        {
            IncreaseCombo();
        }

        //if (combo2)
        //{
        //    scoreAdded *= combo;
        //}
        //if (combo3)
        //{
        //    scoreAdded *= combo;
        //}
        //if (combo4)
        //{
        //    scoreAdded *= combo;
        //}
        //if (combo5)
        //{
        //    scoreAdded *= combo;
        //}
        //if (combo6)
        //{
        //    scoreAdded *= combo;
        //}
        //if (combo7)
        //{
        //    scoreAdded *= combo;
        //}
        //if (combo8)
        //{
        //    scoreAdded *= combo;
        //}
    }

    //public void ScoreSystem()
    //{
    //    ComboSystem();
    //    score += scoreAdded;
    //    
    //    
    //}
    public void ComboSystem()
    {
    }

    public void ApplyScore(int scoreAmount)
    {
        nbPorteCasséesForCombo++;
        this.Scoring += (scoreAmount * this.ComboPoints);
    }

    public void IncreaseCombo()
    {
        this.ComboPoints++;
    }

    public void ResetCombo()
    {
        this.ComboPoints = 1;
    }
}
