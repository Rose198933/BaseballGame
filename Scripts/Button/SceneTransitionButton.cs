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

    // �^�C�g����ʂ���`�[���Z���N�g��ʂ֑J��
    private void GameStartButton()
    {
        SceneManager.LoadScene("TeamSelect");
    }

    // �`�[���Z���N�g��ʂ��玎����ʂ֑J��
    private void PlayBallButton()
    {
        SceneManager.LoadScene("BaseBallGame");
    }
}
