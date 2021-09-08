using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBatCollider : MonoBehaviour
{
    // スイングスピードを決めるパラメータ
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
        // バットの当たり判定が範囲外のときはコライダーをオフにする（9fは目視で決定）
        if(this.transform.position.z >= firstColliderPos.z + 9f)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    // バットコライダーのz軸方向への移動処理
    public void SwingCollider()
    {
        Rigidbody colliderRb = this.GetComponent<Rigidbody>();
        GetComponent<CapsuleCollider>().enabled = true;
        // スイングする際にz座標以外をカーソルの座標に移動する
        Vector3 cursorPos = cursor.transform.position;
        this.transform.position = new Vector3(cursorPos.x, cursorPos.y, firstColliderPos.z);
        Vector3 colliderPos = this.transform.position;

        // コライダーの移動先
        targetPos = new Vector3(colliderPos.x, colliderPos.y, -colliderPos.z);

        Vector3 moveVector = targetPos - colliderPos;
        colliderRb.velocity = moveVector * swingSpeed;
    }

    // コライダーを元の位置に戻す
    public void ResetCollider()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.transform.position = firstColliderPos;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
