using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBatCollider : MonoBehaviour
{
    // �X�C���O�X�s�[�h�����߂�p�����[�^
    public float swingSpeed = 1;
    private Vector3 firstColliderPos;
    private Vector3 targetPos;

    [SerializeField]
    private GameObject cursor;

    void Start()
    {
        firstColliderPos = this.transform.position;
    }

    void Update()
    {
        // �o�b�g�̓����蔻�肪�͈͊O�̂Ƃ��̓R���C�_�[���I�t�ɂ���i9f�͖ڎ��Ō���j
        if(this.transform.position.z >= firstColliderPos.z + 9f)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    // �o�b�g�R���C�_�[��z�������ւ̈ړ�����
    public void SwingCollider()
    {
        Rigidbody colliderRb = this.GetComponent<Rigidbody>();
        GetComponent<CapsuleCollider>().enabled = true;
        // �X�C���O����ۂ�z���W�ȊO���J�[�\���̍��W�Ɉړ�����
        Vector3 cursorPos = cursor.transform.position;
        this.transform.position = new Vector3(cursorPos.x, cursorPos.y, firstColliderPos.z);
        Vector3 colliderPos = this.transform.position;

        // �R���C�_�[�̈ړ���
        targetPos = new Vector3(colliderPos.x, colliderPos.y, -colliderPos.z);

        Vector3 moveVector = targetPos - colliderPos;
        colliderRb.velocity = moveVector * swingSpeed;
    }

    // �R���C�_�[�����̈ʒu�ɖ߂�
    public void ResetCollider()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.transform.position = firstColliderPos;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
