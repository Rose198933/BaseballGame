using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeJudgeManager : MonoBehaviour
{
    public static StrikeJudgeManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Judge()
    {
        if (FlagManager.instance.isStrike)
        {
            Debug.Log("�X�g���C�N�I");
        }
        else if(!FlagManager.instance.isStrike)
        {
            Debug.Log("�{�[���I");
        }
    }
}
