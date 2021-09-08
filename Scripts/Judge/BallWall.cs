using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWall : MonoBehaviour
{
    private Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {
        //�{�[�����X�g���C�N�]�[����ʉ߂������̏���
        if (other.gameObject.tag == "Ball")
        {
            Vector3 ballPosition = other.gameObject.transform.position;
            rb = other.gameObject.GetComponent<Rigidbody>();

            //�X�g���C�N�̃t���O��true���𔻒f
            if(FlagManager.instance.isStrike)
            {
                return;
            }
            StrikeJudgeManager.instance.Judge();

            BallController ballCon = other.gameObject.GetComponent<BallController>();

            //ballCon.sw.Stop();
            rb.useGravity = true;
            //Debug.Log("���Ԃ�" + ballCon.sw.ElapsedMilliseconds + "ms");

            Debug.Log("������" + ballPosition.y);
        }
    }
}
