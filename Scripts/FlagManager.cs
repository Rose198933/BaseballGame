using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ���ʂň����t���O���Ǘ�
 **/
public class FlagManager : MonoBehaviour
{
    public static FlagManager instance;

    // �X�g���C�N���ǂ����̔���
    public bool isStrike = false;
    // �{�[�����o�b�g�ɓ������Ă��邩�ǂ����̔���
    public bool isContact = false;
    // �o�b�^�[�̗����r����(�E�Ŏ�:true, ���Ŏ�:false)
    public bool isRight = true;
    // �X�C���O���Ă��邩�ǂ����̔���
    public bool isSwing = false;
    // �`�[���Z���N�g�̔���
    public bool isTeamSelect = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
