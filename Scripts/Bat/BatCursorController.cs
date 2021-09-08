using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCursorController : MonoBehaviour
{
    private Vector3 cursorPos;
    public float speed;
    private float vertical;
    private float horizontal;

    private Rigidbody rb;

    // �o�b�^�[
    private GameObject player;
    // �o�b�g
    private GameObject bat;
    // �o�b�g�R���C�_�[
    private GameObject batCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Batter");
        bat = GameObject.Find("bat");
        batCollider = GameObject.Find("BatCollider");
    }

    void Update()
    {
        if(!FlagManager.instance.isSwing)
        {
            CursorMove();
        }
    }

    // �\���L�[�ɂ��J�[�\�����ړ�
    private void CursorMove()
    {
        Vector3 playerPos = player.transform.position;
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        Vector3 batPos = bat.transform.position;
        Rigidbody batRb = bat.GetComponent<Rigidbody>();
        //Rigidbody colliderRb = batCollider.GetComponent<Rigidbody>();

        // ���ړ��݂̂̃x�N�g��
        Vector3 moveHorizon;
        // �c���ړ��̃x�N�g��
        Vector3 moveVector;

        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        // �ړ��O��BatController�I�u�W�F�N�g�̍��W
        Vector3 beforeWorldPos = this.transform.position;

        moveHorizon = new Vector3(horizontal, 0, 0);
        moveVector = new Vector3(horizontal, vertical, 0);

        // velocity�́A�������Z�𖳎�����
        rb.velocity = moveVector * speed;
        playerRb.velocity = moveHorizon * speed;
        batRb.velocity = moveHorizon * speed;
        //colliderRb.velocity = moveVector * speed;
        
    }
}
