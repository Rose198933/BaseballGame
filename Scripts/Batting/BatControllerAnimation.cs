using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControllerAnimation : MonoBehaviour
{
    private Animator animator;
    // batColliderをスイングに合わせて動かすオブジェクト
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

    // スイング開始メソッド
    public void SwingAnimation()
    {
        animator.SetBool("Swing", true);
        Invoke("ColliderMove", 0.25f);
    }

    // スイング待機メソッド
    public void SwingIdle()
    {
        animator.SetBool("Swing", false);
        FlagManager.instance.isSwing = false;
        FlagManager.instance.isContact = false;
        colliderController.ResetCollider();
    }

    // コライダーの動作を実行するメソッド
    private void ColliderMove()
    {
        colliderController.SwingCollider();
    }
}
