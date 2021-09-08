using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionButton : ButtonManager
{

    protected override void OnClick(string buttonName)
    {
        if(buttonName.Equals("StartButton"))
        {
            GameStartButton();
        }
        else if(buttonName.Equals("PlayBallButton"))
        {
            PlayBallButton();
        }
    }

    // タイトル画面からチームセレクト画面へ遷移
    private void GameStartButton()
    {
        SceneManager.LoadScene("TeamSelect");
    }

    // チームセレクト画面から試合画面へ遷移
    private void PlayBallButton()
    {
        SceneManager.LoadScene("BaseBallGame");
    }
}
