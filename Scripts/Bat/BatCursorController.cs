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

    // バッター
    private GameObject player;
    // バット
    private GameObject bat;
    // バットコライダー
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

    // 十字キーによりカーソルが移動
    private void CursorMove()
    {
        Vector3 playerPos = player.transform.position;
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        Vector3 batPos = bat.transform.position;
        Rigidbody batRb = bat.GetComponent<Rigidbody>();
        //Rigidbody colliderRb = batCollider.GetComponent<Rigidbody>();

        // 横移動のみのベクトル
        Vector3 moveHorizon;
        // 縦横移動のベクトル
        Vector3 moveVector;

        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        // 移動前のBatControllerオブジェクトの座標
        Vector3 beforeWorldPos = this.transform.position;

        moveHorizon = new Vector3(horizontal, 0, 0);
        moveVector = new Vector3(horizontal, vertical, 0);

        // velocityは、物理演算を無視する
        rb.velocity = moveVector * speed;
        playerRb.velocity = moveHorizon * speed;
        batRb.velocity = moveHorizon * speed;
        //colliderRb.velocity = moveVector * speed;
        
    }
}
