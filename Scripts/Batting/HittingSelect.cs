using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingSelect : MonoBehaviour
{
    // �X�g���C�N�]�[���I�u�W�F�N�g�̔z��
    private GameObject[] strikes = new GameObject[9];
    // �X�g���C�N�]�[���̍��W
    private Vector3[] strikePos = new Vector3[9];
    // �X�g���C�N�]�[����I�����Ă��邩�ǂ����̔���
    private bool[] strikeBool = new bool[9];

    void Start()
    {
        for(int i = 0; i < strikes.Length; i++)
        {
            strikes[i] = GameObject.Find("Strike" + i);
            strikePos[i] = strikes[i].transform.position;
        }
    }

    // �I�������X�g���C�N�]�[���̎擾
    public void GetSelectZone(int selectCourseNum)
    {
        
    }

    // �{�[�����ʂ����R�[�X�̎擾
    public void GetBallCourse(int course, Vector3 ballPos)
    {

    }
}
