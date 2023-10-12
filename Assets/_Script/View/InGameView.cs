using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameView : BaseView
{
    public ControlZone controlzone;
    public TextMeshProUGUI comboIndicator;
    public Image gasbar;
    private PendulumControl pendulum;
    public TextMeshProUGUI scoreIndicator;
    public TextMeshProUGUI status;
    public override void Setup(ViewParam viewParam)
    {    
        controlzone.Initial();
        comboIndicator.text = "Combo";
    }

    private void Start()
    {
   
    }


    private void FixedUpdate()
    {
        if(pendulum==null)
        {
            pendulum = FindObjectOfType<PendulumControl>();
        }
        gasbar.fillAmount = pendulum.currentFuel / pendulum.maxFuel;
     
        scoreIndicator.text= "Score"+ PendulumComboControl.Instance.score.ToString();
        status.text = LevelManager.Instance.wateredPlant.ToString() + "/" + LevelManager.Instance.totalPlant.ToString();    }

}
