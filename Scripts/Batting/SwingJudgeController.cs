using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingJudgeController : MonoBehaviour
{
    // �X�g���C�N�]�[���I�u�W�F�N�g�̔z��
    private GameObject[] strikes = new GameObject[9];
    // �X�g���C�N�]�[���̍��W
    private Vector3[] strikePos = new Vector3[9];
    // �X�g���C�N�]�[���̒���
    private float strikeWidth;
    private float strikeHeight;

    // �Ŏ҃I�u�W�F�N�g
    private GameObject batter;

    void Start()
    {
        for (int i = 0; i < strikes.Length; i++)
        {
            strikes[i] = GameObject.Find("Strike" + i);
            strikePos[i] = strikes[i].transform.position;
        }

        strikeWidth = Mathf.Abs(strikePos[0].x - strikePos[3].x);
        strikeHeight = Mathf.Abs(strikePos[0].y - strikePos[1].y);
    }

    private void OnTriggerExit(Collider other)
    {
        batter = GameObject.FindWithTag("Batter");
        // �ʉߌ�̃{�[���̍��W���擾
        if (other.gameObject.tag == "Ball" && !FlagManager.instance.isSwing)
        {
            FlagManager.instance.isSwing = true;
            batter.GetComponent<BatControllerAnimation>().SwingAnimation();
            Vector3 ballPos = other.gameObject.transform.position;

            /*
            // �{�[�����ʉ߂����R�[�X�̔ԍ�
            int courseNum = 10;

            for(int i = 0; i < strikes.Length; i++)
            {
                // �{�[�����ʉ߂������W���X�g���C�N�]�[���̂ǂ����𒲍�����
                if(ballPos.x >= strikePos[i].x - strikeWidth / 2 && ballPos.x <= strikePos[i].x + strikeWidth / 2
                    && ballPos.y >= strikePos[i].y - strikeHeight / 2 && ballPos.y <= strikePos[i].y + strikeHeight / 2)
                {
                    courseNum = i;
                }
                else
                {
                    continue;
                }
            }

            HittingSelect hs = GameObject.Find("HittingSelectManager").GetComponent<HittingSelect>();
            hs.GetBallCourse(courseNum, ballPos);
            */
        }

        
    }
}
