using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MySingleton<LevelManager>
{
    public int totalPlant;
    public int wateredPlant;
    private ResultViewParams resultParam;
    public int levelIndex = 1;

    private void Start()
    {
    }
    public void Reset()
    {
        wateredPlant = 0;
        totalPlant = 0;
    }    
    public void CheckWinCondition()
    {
        if (wateredPlant >= totalPlant && ViewManager.Instance.currentView.viewIndex != ViewIndex.ResultView)
        {
            resultParam = new ResultViewParams();
            resultParam.result = Result.completed;
            ViewManager.Instance.SwitchView(ViewIndex.ResultView, resultParam);
        }
    }
    public void LoadLevel(int levelIndex)
    {
        if (levelIndex == 1)
        {
            Reset();
            LoadSceenManager.Instance.LoadScence("Level1", () =>
            {
                ViewManager.Instance.SwitchView(ViewIndex.InGameView);
                MusicManager.Instance.PlayLevelMusic();
                this.levelIndex = 1;
            });
        }
        if (levelIndex == 2)
        {
            Reset();
            LoadSceenManager.Instance.LoadScence("Level2", () =>
            {
                ViewManager.Instance.SwitchView(ViewIndex.InGameView);
                MusicManager.Instance.PlayLevelMusic();
                this.levelIndex = 2;

            });
        }
        if (levelIndex >=3)
        {
            Reset();
            LoadSceenManager.Instance.LoadScence("Level3", () =>
            {
                ViewManager.Instance.SwitchView(ViewIndex.InGameView);
                MusicManager.Instance.PlayLevelMusic();
                this.levelIndex = 3;
            });
        }
    }
}
