using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTeamIcon : MonoBehaviour
{
    // �`�[���Z���N�g��ʑS��
    [SerializeField]
    private GameObject display;
    // ��ʂ̍���
    private float height;
    // ��ʂ̕�
    private float width;
    // �`�[���A�C�R��
    [SerializeField]
    private GameObject teamIcon;
    // �`�[���A�C�R���̍���
    private float iconHeight = 400;
    // �`�[���A�C�R���̕�
    private float iconWidth = 400;
    // �`�[���A�C�R���̐�
    private int iconNumber;
    // �A�C�R���Ԃ̕��A�܂���ʒ[�Ƃ̕�
    private float iconSpace = 40;

    // �`�[���f�[�^�x�[�X�i�`�[�������擾���邽�߁j
    [SerializeField]
    private TeamDatabase database;
    private List<Teams> teamList;

    [SerializeField]
    private GameObject canvas;

    void Start()
    {
        teamList = database.GetTeamList();
        IconSet();
    }

    // �`�[���A�C�R����z�u����
    private void IconSet()
    {
        height = display.GetComponent<RectTransform>().sizeDelta.y;
        width = display.GetComponent<RectTransform>().sizeDelta.x;
        iconNumber = teamList.Count;
        iconHeight = teamIcon.GetComponent<RectTransform>().sizeDelta.y;
        iconWidth = teamIcon.GetComponent<RectTransform>().sizeDelta.x;

        // ���̃A�C�R���̍ő吔��5�ɐݒ�
        // ����`�[�����͍ő�10�Ƃ���i5 �~ 2�j
        float firstRowPosY = -(iconSpace + iconHeight / 2);
        float secondRowPosY = firstRowPosY * 2 - iconHeight / 2;

        for (int i = 0; i < teamList.Count; i++)
        {
            Vector3 teamPos;
            if (i < (iconNumber / 2))
            {
                float posX = -(iconWidth / 2 * ((iconNumber / 2 - 1) - i * 2) + (iconSpace * ((iconNumber / 2 - 3) - i)));
                teamPos = new Vector3(posX, firstRowPosY, 0);
            }
            else
            {
                float posX = -(iconWidth / 2 * ((iconNumber / 2 * 3 - 1) - i * 2) + (iconSpace * ((iconNumber - 3) - i)));
                teamPos = new Vector3(posX, secondRowPosY, 0);
            }

            // �A�C�R���t���[���𐶐����A�C���X�^���X��
            GameObject iconFrame = (GameObject)Resources.Load("TeamIconFramework");
            iconFrame.GetComponent<TeamIconController>().SetTeamData(teamList[i]);
            iconFrame.GetComponent<TeamIconController>().GetImage();
            GameObject instance = Instantiate(iconFrame, teamPos, Quaternion.identity);

            // �C���X�^���X��Canvas�ɐݒu
            instance.transform.SetParent(canvas.transform, false);
        }

        // �A�C�R������ׂ��Ƃ��̉�ʒ[����[�܂ł̒����i���Ƃ�try-catch�ɕύX�\��j
        float totalWidth;

        if(iconSpace > 5)
        {
            totalWidth = 5 * (iconSpace + iconWidth) + iconSpace;
        }
        else
        {
            totalWidth = iconNumber * (iconSpace + iconWidth) + iconSpace;
        }

        if(totalWidth > width)
        {
            Debug.Log("�I�[�o�[�I");
        }
    }
}
