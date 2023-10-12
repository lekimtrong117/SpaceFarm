using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumComboControl : MySingleton<PendulumComboControl>
{
    private int previousSpinCount;
    private int currentSpinCount;
    private bool isCombo;
    private InGameView inGameView;
    private int comboCount;
    public float score;
    private void Awake()
    {
        previousSpinCount = 0;
        currentSpinCount = 0;
        comboCount = 0;
        score = 0;
    }

    private void Start()
    {
       
    }
    public void AddCount()
    {
       score+=comboCount;
        currentSpinCount++;
        if (currentSpinCount >= previousSpinCount && isCombo == false) 
        {
            comboCount++;
            if(inGameView==null)
            {  
                inGameView=FindObjectOfType<InGameView>();
            }
            if (inGameView != null)
                inGameView.comboIndicator.text = "COMBO x" + comboCount.ToString();
            isCombo = true;
        }
    }
    public void ResetSpinCount()
    {
        previousSpinCount = currentSpinCount;
        currentSpinCount = 0;
        isCombo = false;
    }
       
}
