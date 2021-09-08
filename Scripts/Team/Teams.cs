using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Team", menuName = "CreateTeam")]
public class Teams : ScriptableObject
{
    // チーム名
    [SerializeField]
    private string teamName;
    // チームアイコン
    [SerializeField]
    private Sprite teamIcon;

    // 監督
    private GameObject director;
    // 投手リスト
    private List<GameObject> pitchers;
    // 捕手リスト
    private List<GameObject> catchers;
    // 内野手リスト
    private List<GameObject> infielders;
    // 外野手リスト
    private List<GameObject> outfielders;

    public GameObject GetSetData
    {
        get; set;
    }

    public string GetSetName
    {
        get; set;
    }

    public Sprite GetIcon()
    {
        return teamIcon;
    }

}
