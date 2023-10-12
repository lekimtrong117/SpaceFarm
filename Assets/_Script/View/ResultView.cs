using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultView : BaseView
{
    private TextMeshProUGUI title;
    public TextMeshProUGUI score;
    public Button nextButton;
    private void Awake()
    {
        viewAnimation = GetComponentInChildren<BaseViewAnimation>();
        title = viewAnimation.GetComponentInChildren<TextMeshProUGUI>();
    }
    public override void Setup(ViewParam viewParam)
    {
        base.Setup(viewParam);
        ResultViewParams resultViewParams = (ResultViewParams)viewParam;
        if (resultViewParams.result ==Result.completed)
        {
            title.text = "Completed";
            nextButton.interactable = true;
        }    
            
        if (resultViewParams.result == Result.crash)
        {
            title.text = "Ship Crash";
            nextButton.interactable = false;
        }    
            

        if (resultViewParams.result == Result.fuelRunOut)
        {
            title.text = "Fuel Run Out";
            nextButton.interactable = false;
        }    
        score.text = "Score:  "+ PendulumComboControl.Instance.score.ToString();
        SaveScore();
    }
    public void OnHomeButton()
    {
        MusicManager.Instance.audioSource.PlayOneShot(MusicManager.Instance.button);
        LoadSceenManager.Instance.LoadScence("Buffer", () =>
        {
            ViewManager.Instance.SwitchView(ViewIndex.HomeView);

        });
    }
    public void OnReplayButton()
    {
        MusicManager.Instance.audioSource.PlayOneShot(MusicManager.Instance.button);
        LevelManager.Instance.LoadLevel(LevelManager.Instance.levelIndex);
    }
    public void OnNextButton()
    {
        MusicManager.Instance.audioSource.PlayOneShot(MusicManager.Instance.button);
        LevelManager.Instance.LoadLevel(LevelManager.Instance.levelIndex+1);
    }    
    private void SaveScore()
    {
        if (PendulumComboControl.Instance.score>DataAPIController.Instance.ReadHighestScore())
        {
            DataAPIController.Instance.UpdateHighrestScore(PendulumComboControl.Instance.score);
        }    
    }    
}

public class ResultViewParams:ViewParam
{
    public Result result;
}
public enum Result
{
    completed=0,
    crash=1,
    fuelRunOut=2
}
