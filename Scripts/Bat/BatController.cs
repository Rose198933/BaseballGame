using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    // �~�[�g�J�[�\��
    [SerializeField]
    private GameObject cursor;
    private Vector3 cursorPos;
    // �o�b�g�̓����蔻��
    private Vector3 firstColliderPos;
    private CapsuleCollider capsule;
    // �o�b�g�R���C�_�[�ƃ{�[���̐ڐG���W
    private Vector3 contactPos;
    // �{�[�����o�b�g�R���C�_�[�ɐڐG�������Ƀ{�[���̍��W
    private Vector3 ballContactPos;
    // �{�[�����o�b�g�R���C�_�[�ɐڐG�������Ƀo�b�g�R���C�_�[�̍��W
    private Vector3 batContactPos;
    private float tan;
    // �J�[�\���ƃ{�[�������������R���C�_�[�̋���
    private Vector3 distance;
    // �ŋ����������߂�Ƃ��Ɏg�p�����x�N�g��Vx
    private Vector3 standard = Vector3.zero;

    // �ŋ������������Ă��邩�����Ă��邩�̔���
    private bool isPull;

    // �ŋ��̋���
    [SerializeField]
    private float firstHitPower = 100;
    // �ŋ��̉�]����
    private float spinDirectionX;
    private float spinDirectionY;

    private AudioSource audio;
    [SerializeField]
    private AudioClip hitSound;

    void Start()
    {
        firstColliderPos = this.transform.position;
        capsule = GetComponent<CapsuleCollider>();
        audio = GetComponent<AudioSource>();
    }

    // �{�[���ɓ��������Ƃ��̏���
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            audio.PlayOneShot(hitSound);
            BallController ballCon = other.gameObject.GetComponent<BallController>();

            contactPos = other.ClosestPointOnBounds(this.transform.position);
            ballContactPos = other.gameObject.transform.position;
            batContactPos = this.transform.position;
            Debug.Log(contactPos);

            // �o�b�g�R���C�_�[�͈͓̔��Ȃ�{�[���͓�����
            if(contactPos.z < firstColliderPos.z + 9f && contactPos.z > firstColliderPos.z)
            {
                ballCon.HitDirection(HitDirection(), ballContactPos, batContactPos, new Vector3(spinDirectionX, spinDirectionY,0));
            }
        }
    }

    // �ŋ������̌���
    private Vector3 HitDirection()
    {
        cursorPos = cursor.transform.position;
        // �J�[�\���ƐڐG�����{�[���̍��W�̍����Z�o
        distance = contactPos - cursorPos;
        tan = distance.z / capsule.height;
        float hitAngle = 0;

        // �ŋ����������߂�x�N�g��
        Vector3 hitDirection = Vector3.zero;

        // ��������Ȃ�
        if(distance.z >= 0)
        {
            isPull = true;
            hitAngle = Mathf.Abs(Mathf.Atan(tan) * Mathf.Rad2Deg);
            standard = new Vector3(-HitPower(distance), 0, 0);
            hitDirection = new Vector3(standard.x, 0, -standard.x / Mathf.Cos(Mathf.PI / 180 * hitAngle));
        }
        // �����ł��Ȃ�
        else if(distance.z < 0)
        {
            isPull = false;
            hitAngle = 90 - Mathf.Abs(Mathf.Atan(tan) * Mathf.Rad2Deg);
            standard = new Vector3(HitPower(distance), 0, 0);
            hitDirection = new Vector3(standard.x, 0, standard.x / Mathf.Cos(Mathf.PI / 180 * hitAngle));
        }

        Debug.Log("�ŋ�������" + hitDirection);
        return hitDirection;
    }

    // �ŋ��̋���������
    private float HitPower(Vector3 distance)
    {
        // �R���C�_�[�̈ʒu�����擾
        Vector3 colliderPos = this.transform.position;
        Vector3 colliderScale = this.transform.lossyScale;
        // �J�[�\���͈̔͂��擾�i�J�[�\�����V�����g���[�łȂ��ꍇ�A�ǋL���K�v�j
        float rangeX = colliderScale.x / 2;
        float rangeY = colliderScale.y / 2;

        float hitPowerX;
        float hitPowerY;

        // �ŋ��̋����̊��������肷��͈͂�ݒ�
        // ���S����20���͈̔�
        if(contactPos.x > colliderPos.x - rangeX * 0.2 && contactPos.x < colliderPos.x + rangeX * 0.2)
        {
            hitPowerX = firstHitPower;
        }
        // ���S����40���͈̔�
        else if(contactPos.x > colliderPos.x - rangeX * 0.4 && contactPos.x < colliderPos.x + rangeX * 0.4)
        {
            hitPowerX = firstHitPower *  0.9f;
        }
        // ���S����60���͈̔�
        else if(contactPos.x > colliderPos.x - rangeX * 0.6 && contactPos.x < colliderPos.x + rangeX * 0.6)
        {
            hitPowerX = firstHitPower * 0.7f;
        }
        // ���S����80���͈̔�
        else if(contactPos.x > colliderPos.x - rangeX * 0.8 && contactPos.x < colliderPos.x + rangeX * 0.8)
        {
            hitPowerX = firstHitPower * 0.3f;
        }
        else
        {
            hitPowerX = firstHitPower * 0.05f;
        }

        if (contactPos.y > colliderPos.y - rangeY * 0.2 && contactPos.y < colliderPos.y + rangeY * 0.2)
        {
            hitPowerY = firstHitPower;
        }
        // ���S����40���͈̔�
        else if (contactPos.y > colliderPos.y - rangeY * 0.4 && contactPos.y < colliderPos.y + rangeY * 0.4)
        {
            hitPowerY = firstHitPower *  0.9f;
        }
        // ���S����60���͈̔�
        else if (contactPos.y > colliderPos.y - rangeY * 0.6 && contactPos.y < colliderPos.y + rangeY * 0.6)
        {
            hitPowerY = firstHitPower * 0.7f;
        }
        // ���S����80���͈̔�
        else if (contactPos.y > colliderPos.y - rangeY * 0.8 && contactPos.y < colliderPos.y + rangeY * 0.8)
        {
            hitPowerY = firstHitPower * 0.3f;
        }
        else
        {
            hitPowerY = firstHitPower * 0.05f;
        }

        // �ł������̃{�[����Y����]
        if(isPull)
        {
            spinDirectionY = -hitPowerX;
        }
        else
        {
            spinDirectionY = hitPowerX;
        }

        // �ł������̃{�[����X����]
        if(contactPos.y > colliderPos.y)
        {
            spinDirectionX = hitPowerY;
        }
        else
        {
            spinDirectionX = -hitPowerY;
        }

        float hitPower = Mathf.Min(hitPowerX, hitPowerY);

        return hitPower;
    }
}
