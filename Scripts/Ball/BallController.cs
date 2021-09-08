using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float hitPower;
    [SerializeField]
    private float spin;
    [SerializeField]
    private float arch;
    // �ŋ��p�x�̕␳
    [SerializeField]
    private float angleRevision;

    [SerializeField]
    private Vector3 releasePos;
    [SerializeField]
    private Vector3 targetPos;
    private Vector3 addVector;

    // �ŋ��̊p�x
    private float ballAngle;

    //public System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    // �{�[���𓊂��鏈��
    public void Throw(Vector3 coursePos)
    {
        rb = this.GetComponent<Rigidbody>();

        releasePos = this.transform.position;
        targetPos = coursePos;
        addVector = (targetPos - releasePos);
        rb.AddForce(addVector * speed);
        rb.AddTorque(new Vector3(1000, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {

        // �o�b�g�őł������ɁA�{�[���̏d�͂��I���ɂ���
        if(other.gameObject.tag == "Bat")
        {
            rb.useGravity = true;
        }
    }

    // �ŋ������Ɗp�x������
    /**
     * param : �ŋ������A�o�b�g�ƃ{�[�����ڐG�������̃{�[���̍��W�A�o�b�g�̍��W
     * 
     */
    public void HitDirection(Vector3 direction, Vector3 ballContactPos, Vector3 batContactPos, Vector3 spinVector)
    {

        // �{�[���̊p�x�i���W�A���j���v�Z
        Vector3 dt = ballContactPos - batContactPos;
        ballAngle = Mathf.Atan(dt.y / Mathf.Abs(dt.z));
        Debug.Log("ballAngle" + ballAngle);

        // �ŋ���y���W�����߂�
        float vectorXZ = Mathf.Sqrt(direction.x * direction.x + direction.z * direction.z);
        float vectorY = Mathf.Tan(ballAngle) * vectorXZ;

        /*// �{�[���ƃo�b�g�̊p�x����ŋ��̋����ɑ΂���␳�����߂�
        float angleRevision = ballAngle / batAngle;

        if(ballAngle != 0 && batAngle != 0)
        {
            angleRevision = ballAngle / batAngle;
        }
        else
        {
            angleRevision = 1;
        }

        if (angleRevision > 1)
        {
            angleRevision = 1 / angleRevision;
        }
        Debug.Log("�p�x�␳��" + angleRevision);
        */

        // �ŋ������Ɗp�x�����肵���x�N�g��
        Vector3 hitVector = new Vector3(direction.x, vectorY, direction.z);

        // �t�@�E�������̃x�N�g��
        Vector3 backVector = hitVector * Mathf.Tan(ballAngle);

        if (ballAngle > 0)
        {
            backVector.x = -backVector.x;
            backVector.z = -backVector.z;
        }
        else if(ballAngle < 0)
        {
            backVector.y = -backVector.y;
        }

        Debug.Log("back " + backVector);
        // �ŋ���x,z�����Ƀp���[��������B
        hitVector.x *= hitPower;
        hitVector.z *= hitPower;

        // �ŋ��p�x���v���X�Ȃ�e���l���悹��
        if (ballAngle > 0)
        {
            hitVector.y *= arch;
        }

        Debug.Log("hit is " + hitVector);

        // �{�[���ɉ�����x�N�g��
        Vector3 addVector = hitVector + backVector;

        /*if(addVector.z > 0)
        {
            rb.AddForce(addVector * hitPower);
        }
        else
        {
            addVector.x *= hitPower / 2;
            addVector.z *= hitPower / 2;
            rb.AddForce(addVector);
        }*/

        rb.AddForce(addVector);

        // �ŋ��ɉ�]��������
        rb.maxAngularVelocity = Mathf.Infinity;
        rb.AddTorque(spinVector);
    }
}
