using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    Movements playerController;
    [SerializeField] int scoreInt;
    [SerializeField] int scoreAdded = 10;
    [SerializeField] int nbPorteCass�esForCombo;
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

        if (nbPorteCass�esForCombo > 4 && nbPorteCass�esForCombo <= 9)
        {
            IncreaseCombo();
        }
        if (nbPorteCass�esForCombo > 9 && nbPorteCass�esForCombo <= 14)
        {
            IncreaseCombo();
        }
        if (nbPorteCass�esForCombo > 14 && nbPorteCass�esForCombo <= 19)
        {
            IncreaseCombo();
        }
        if (nbPorteCass�esForCombo > 19 && nbPorteCass�esForCombo <= 24)
        {
            IncreaseCombo();
        }
        if (nbPorteCass�esForCombo > 24 && nbPorteCass�esForCombo <= 29)
        {
            IncreaseCombo();
        }
        if (nbPorteCass�esForCombo > 29 && nbPorteCass�esForCombo <= 34)
        {
            IncreaseCombo();
        }
        if (nbPorteCass�esForCombo > 34 && nbPorteCass�esForCombo <= 39)
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
        nbPorteCass�esForCombo++;
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
