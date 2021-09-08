using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControllerAnimation : MonoBehaviour
{
    private Animator animator;
    // batCollider���X�C���O�ɍ��킹�ē������I�u�W�F�N�g
    [SerializeField]
    private SwingBatCollider colliderController;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Swing", true);
            Invoke("ColliderMove", 0.25f);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("Swing", false);
            FlagManager.instance.isSwing = false;
            FlagManager.instance.isContact = false;
            colliderController.ResetCollider();
        }
    }

    // �X�C���O�J�n���\�b�h
    public void SwingAnimation()
    {
        animator.SetBool("Swing", true);
        Invoke("ColliderMove", 0.25f);
    }

    // �X�C���O�ҋ@���\�b�h
    public void SwingIdle()
    {
        animator.SetBool("Swing", false);
        FlagManager.instance.isSwing = false;
        FlagManager.instance.isContact = false;
        colliderController.ResetCollider();
    }

    // �R���C�_�[�̓�������s���郁�\�b�h
    private void ColliderMove()
    {
        colliderController.SwingCollider();
    }
}
