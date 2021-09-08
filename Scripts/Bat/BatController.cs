using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    // ミートカーソル
    [SerializeField]
    private GameObject cursor;
    private Vector3 cursorPos;
    // バットの当たり判定
    private Vector3 firstColliderPos;
    private CapsuleCollider capsule;
    // バットコライダーとボールの接触座標
    private Vector3 contactPos;
    // ボールがバットコライダーに接触した時にボールの座標
    private Vector3 ballContactPos;
    // ボールがバットコライダーに接触した時にバットコライダーの座標
    private Vector3 batContactPos;
    private float tan;
    // カーソルとボールが当たったコライダーの距離
    private Vector3 distance;
    // 打球方向を決めるときに使用する基準ベクトルVx
    private Vector3 standard = Vector3.zero;

    // 打球を引っ張っているか流しているかの判定
    private bool isPull;

    // 打球の強さ
    [SerializeField]
    private float firstHitPower = 100;
    // 打球の回転方向
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

    // ボールに当たったときの処理
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

            // バットコライダーの範囲内ならボールは当たる
            if(contactPos.z < firstColliderPos.z + 9f && contactPos.z > firstColliderPos.z)
            {
                ballCon.HitDirection(HitDirection(), ballContactPos, batContactPos, new Vector3(spinDirectionX, spinDirectionY,0));
            }
        }
    }

    // 打球方向の決定
    private Vector3 HitDirection()
    {
        cursorPos = cursor.transform.position;
        // カーソルと接触したボールの座標の差を算出
        distance = contactPos - cursorPos;
        tan = distance.z / capsule.height;
        float hitAngle = 0;

        // 打球方向を決めるベクトル
        Vector3 hitDirection = Vector3.zero;

        // 引っ張りなら
        if(distance.z >= 0)
        {
            isPull = true;
            hitAngle = Mathf.Abs(Mathf.Atan(tan) * Mathf.Rad2Deg);
            standard = new Vector3(-HitPower(distance), 0, 0);
            hitDirection = new Vector3(standard.x, 0, -standard.x / Mathf.Cos(Mathf.PI / 180 * hitAngle));
        }
        // 流し打ちなら
        else if(distance.z < 0)
        {
            isPull = false;
            hitAngle = 90 - Mathf.Abs(Mathf.Atan(tan) * Mathf.Rad2Deg);
            standard = new Vector3(HitPower(distance), 0, 0);
            hitDirection = new Vector3(standard.x, 0, standard.x / Mathf.Cos(Mathf.PI / 180 * hitAngle));
        }

        Debug.Log("打球方向は" + hitDirection);
        return hitDirection;
    }

    // 打球の強さを決定
    private float HitPower(Vector3 distance)
    {
        // コライダーの位置情報を取得
        Vector3 colliderPos = this.transform.position;
        Vector3 colliderScale = this.transform.lossyScale;
        // カーソルの範囲を取得（カーソルがシンメトリーでない場合、追記が必要）
        float rangeX = colliderScale.x / 2;
        float rangeY = colliderScale.y / 2;

        float hitPowerX;
        float hitPowerY;

        // 打球の強さの割合を決定する範囲を設定
        // 中心から20％の範囲
        if(contactPos.x > colliderPos.x - rangeX * 0.2 && contactPos.x < colliderPos.x + rangeX * 0.2)
        {
            hitPowerX = firstHitPower;
        }
        // 中心から40％の範囲
        else if(contactPos.x > colliderPos.x - rangeX * 0.4 && contactPos.x < colliderPos.x + rangeX * 0.4)
        {
            hitPowerX = firstHitPower *  0.9f;
        }
        // 中心から60％の範囲
        else if(contactPos.x > colliderPos.x - rangeX * 0.6 && contactPos.x < colliderPos.x + rangeX * 0.6)
        {
            hitPowerX = firstHitPower * 0.7f;
        }
        // 中心から80％の範囲
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
        // 中心から40％の範囲
        else if (contactPos.y > colliderPos.y - rangeY * 0.4 && contactPos.y < colliderPos.y + rangeY * 0.4)
        {
            hitPowerY = firstHitPower *  0.9f;
        }
        // 中心から60％の範囲
        else if (contactPos.y > colliderPos.y - rangeY * 0.6 && contactPos.y < colliderPos.y + rangeY * 0.6)
        {
            hitPowerY = firstHitPower * 0.7f;
        }
        // 中心から80％の範囲
        else if (contactPos.y > colliderPos.y - rangeY * 0.8 && contactPos.y < colliderPos.y + rangeY * 0.8)
        {
            hitPowerY = firstHitPower * 0.3f;
        }
        else
        {
            hitPowerY = firstHitPower * 0.05f;
        }

        // 打った時のボールのY軸回転
        if(isPull)
        {
            spinDirectionY = -hitPowerX;
        }
        else
        {
            spinDirectionY = hitPowerX;
        }

        // 打った時のボールのX軸回転
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
