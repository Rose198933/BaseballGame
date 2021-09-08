using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingJudgeController : MonoBehaviour
{
    // ストライクゾーンオブジェクトの配列
    private GameObject[] strikes = new GameObject[9];
    // ストライクゾーンの座標
    private Vector3[] strikePos = new Vector3[9];
    // ストライクゾーンの長さ
    private float strikeWidth;
    private float strikeHeight;

    // 打者オブジェクト
    private GameObject batter;

    void Start()
    {
        for (int i = 0; i < strikes.Length; i++)
        {
            strikes[i] = GameObject.Find("Strike" + i);
            strikePos[i] = strikes[i].transform.position;
        }

        strikeWidth = Mathf.Abs(strikePos[0].x - strikePos[3].x);
        strikeHeight = Mathf.Abs(strikePos[0].y - strikePos[1].y);
    }

    private void OnTriggerExit(Collider other)
    {
        batter = GameObject.FindWithTag("Batter");
        // 通過後のボールの座標を取得
        if (other.gameObject.tag == "Ball" && !FlagManager.instance.isSwing)
        {
            FlagManager.instance.isSwing = true;
            batter.GetComponent<BatControllerAnimation>().SwingAnimation();
            Vector3 ballPos = other.gameObject.transform.position;

            /*
            // ボールが通過したコースの番号
            int courseNum = 10;

            for(int i = 0; i < strikes.Length; i++)
            {
                // ボールが通過した座標がストライクゾーンのどこかを調査する
                if(ballPos.x >= strikePos[i].x - strikeWidth / 2 && ballPos.x <= strikePos[i].x + strikeWidth / 2
                    && ballPos.y >= strikePos[i].y - strikeHeight / 2 && ballPos.y <= strikePos[i].y + strikeHeight / 2)
                {
                    courseNum = i;
                }
                else
                {
                    continue;
                }
            }

            HittingSelect hs = GameObject.Find("HittingSelectManager").GetComponent<HittingSelect>();
            hs.GetBallCourse(courseNum, ballPos);
            */
        }

        
    }
}
