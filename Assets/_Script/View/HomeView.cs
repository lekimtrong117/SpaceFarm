using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomeView : BaseView
{
    public TextMeshProUGUI scoreIndicator;
   public void OnPlayButton()
    {
        LevelManager.Instance.LoadLevel(1);
        MusicManager.Instance.audioSource.PlayOneShot(MusicManager.Instance.button);
    }
    public override void Setup(ViewParam viewParam)
    {
        base.Setup(viewParam);

        MusicManager.Instance.PlayMenuMusic();
        scoreIndicator.text= "Your highest score:" + DataAPIController.Instance.ReadHighestScore().ToString();
    }
}
