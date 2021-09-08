using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattingCommand : ButtonManager
{
    [SerializeField]
    private GameObject swingJudge;
    // スイング判定オブジェクトの初期位置
    private Vector3 startPos;

    void Start()
    {
        startPos = swingJudge.transform.position;
    }

    protected override void OnClick(string buttonName)
    {
        // オブジェクトの位置を変更するパラメータ
        float addZ = 0;
        
        // 乱数で決める
        if(buttonName.Equals("CenterHit"))
        {
            addZ = 0;
        }
        if (buttonName.Equals("PullHit"))
        {
            addZ = 10;
        }
        else if(buttonName.Equals("ReverseHit"))
        {
            addZ = -10;
        }

        swingJudge.transform.position = startPos + new Vector3(0, 0, addZ);
    }
}
