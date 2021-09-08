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
    // 打球角度の補正
    [SerializeField]
    private float angleRevision;

    [SerializeField]
    private Vector3 releasePos;
    [SerializeField]
    private Vector3 targetPos;
    private Vector3 addVector;

    // 打球の角度
    private float ballAngle;

    //public System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    // ボールを投げる処理
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

        // バットで打った時に、ボールの重力をオンにする
        if(other.gameObject.tag == "Bat")
        {
            rb.useGravity = true;
        }
    }

    // 打球方向と角度を決定
    /**
     * param : 打球方向、バットとボールが接触した時のボールの座標、バットの座標
     * 
     */
    public void HitDirection(Vector3 direction, Vector3 ballContactPos, Vector3 batContactPos, Vector3 spinVector)
    {

        // ボールの角度（ラジアン）を計算
        Vector3 dt = ballContactPos - batContactPos;
        ballAngle = Mathf.Atan(dt.y / Mathf.Abs(dt.z));
        Debug.Log("ballAngle" + ballAngle);

        // 打球のy座標を決める
        float vectorXZ = Mathf.Sqrt(direction.x * direction.x + direction.z * direction.z);
        float vectorY = Mathf.Tan(ballAngle) * vectorXZ;

        /*// ボールとバットの角度から打球の強さに対する補正を決める
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
        Debug.Log("角度補正は" + angleRevision);
        */

        // 打球方向と角度を決定したベクトル
        Vector3 hitVector = new Vector3(direction.x, vectorY, direction.z);

        // ファウル方向のベクトル
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
        // 打球のx,z方向にパワーを加える。
        hitVector.x *= hitPower;
        hitVector.z *= hitPower;

        // 打球角度がプラスなら弾道値を乗せる
        if (ballAngle > 0)
        {
            hitVector.y *= arch;
        }

        Debug.Log("hit is " + hitVector);

        // ボールに加えるベクトル
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

        // 打球に回転を加える
        rb.maxAngularVelocity = Mathf.Infinity;
        rb.AddTorque(spinVector);
    }
}
