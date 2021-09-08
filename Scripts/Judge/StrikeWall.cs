using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWall : MonoBehaviour
{
    private Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {
        //ボールがストライクゾーンを通過した時の処理
        if(other.gameObject.tag == "Ball")
        {
            Vector3 ballPosition = other.gameObject.transform.position;
            rb = other.gameObject.GetComponent<Rigidbody>();

            //ストライクのフラグをtrueにする
            FlagManager.instance.isStrike = true;
            StrikeJudgeManager.instance.Judge();

            //BallController ballCon = other.gameObject.GetComponent<BallController>();

            //ballCon.sw.Stop();
            rb.useGravity = true;
            //Debug.Log("時間は" + ballCon.sw.ElapsedMilliseconds + "ms");

            Debug.Log("高さは" + ballPosition.y);
        }
    }
}
