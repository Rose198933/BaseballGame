using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattingCommand : ButtonManager
{
    [SerializeField]
    private GameObject swingJudge;
    // �X�C���O����I�u�W�F�N�g�̏����ʒu
    private Vector3 startPos;

    void Start()
    {
        startPos = swingJudge.transform.position;
    }

    protected override void OnClick(string buttonName)
    {
        // �I�u�W�F�N�g�̈ʒu��ύX����p�����[�^
        float addZ = 0;
        
        // �����Ō��߂�
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
