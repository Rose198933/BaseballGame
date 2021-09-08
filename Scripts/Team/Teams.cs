using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Team", menuName = "CreateTeam")]
public class Teams : ScriptableObject
{
    // �`�[����
    [SerializeField]
    private string teamName;
    // �`�[���A�C�R��
    [SerializeField]
    private Sprite teamIcon;

    // �ē�
    private GameObject director;
    // ���胊�X�g
    private List<GameObject> pitchers;
    // �ߎ胊�X�g
    private List<GameObject> catchers;
    // ����胊�X�g
    private List<GameObject> infielders;
    // �O��胊�X�g
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
