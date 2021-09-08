using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 共通で扱うフラグを管理
 **/
public class FlagManager : MonoBehaviour
{
    public static FlagManager instance;

    // ストライクかどうかの判定
    public bool isStrike = false;
    // ボールがバットに当たっているかどうかの判定
    public bool isContact = false;
    // バッターの利き腕判定(右打者:true, 左打者:false)
    public bool isRight = true;
    // スイングしているかどうかの判定
    public bool isSwing = false;
    // チームセレクトの判定
    public bool isTeamSelect = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
