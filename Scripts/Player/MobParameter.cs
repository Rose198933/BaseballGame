using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobParameter : MonoBehaviour
{
    // 選手名
    private string name;
    // ポジション
    private Dictionary<int, string> position = new Dictionary<int, string>()
    {
        {1, "投手" },
        {2, "捕手" },
        {3, "一塁手" },
        {4, "二塁手" },
        {5, "三塁手" },
        {6, "遊撃手" },
        {7, "外野手" }
    };
    // 利き手
    private Dictionary<int, string> handedness = new Dictionary<int, string>()
    {
        {0, "右投げ右打ち" },
        {1, "右投げ左打ち" },
        {2, "右投げ両打ち" },
        {3, "左投げ右打ち" },
        {4, "左投げ左打ち" },
        {5, "左投げ両打ち" }
    };

    // 球速
    private int speedBall;
    // コントロール
    private int control;
    // スタミナ
    private int stamina;

    // パワー
    private int power;
    // ミート
    private int contact;
    // 走力
    private int speed;
    // 肩力
    private int throwing;
    // 守備力
    private int deffence;
    // 捕球
    private int catching;

    public MobParameter()
    {
        RandomParameterSet();
    }

    public void RandomParameterSet()
    {
        GetSetName = "田中";
    }

    // 選手名のセッター、ゲッター
    public string GetSetName
    {
        get; set;
    }

    // ポジションのゲッター
    public string GetPosition(int key)
    {
        return position[key];
    }

    // 利き手のゲッター
    public string GetHand(int key)
    {
        return handedness[key];
    }

    // 球速のゲッターセッター
    public int GetSetSpeedBall
    {
        get; set;
    }

    // コントロールのゲッターセッター
    public int GetSetControl
    {
        get; set;
    }

    // スタミナのゲッターセッター
    public int GetSetStamina
    {
        get; set;
    }

    // パワーのゲッターセッター
    public int GetSetPower
    {
        get; set;
    }

    // ミートのゲッターセッター
    public int GetSetContact
    {
        get; set;
    }

    // 走力のゲッターセッター
    public int GetSetSpeed
    {
        get; set;
    }

    // 肩力のゲッターセッター
    public int GetSetThrowing
    {
        get; set;
    }

    // 守備力のゲッターセッター
    public int GetSetDeffence
    {
        get; set;
    }

    // 捕球のゲッターセッター
    public int GetSetCatching
    {
        get; set;
    }
}
