using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingSelect : MonoBehaviour
{
    // ストライクゾーンオブジェクトの配列
    private GameObject[] strikes = new GameObject[9];
    // ストライクゾーンの座標
    private Vector3[] strikePos = new Vector3[9];
    // ストライクゾーンを選択しているかどうかの判定
    private bool[] strikeBool = new bool[9];

    void Start()
    {
        for(int i = 0; i < strikes.Length; i++)
        {
            strikes[i] = GameObject.Find("Strike" + i);
            strikePos[i] = strikes[i].transform.position;
        }
    }

    // 選択したストライクゾーンの取得
    public void GetSelectZone(int selectCourseNum)
    {
        
    }

    // ボールが通ったコースの取得
    public void GetBallCourse(int course, Vector3 ballPos)
    {

    }
}
