using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMobPlayer : MonoBehaviour
{

    // ���u����̃v���n�u�𐶐����A�`�[���N���X�ɓn��
    public GameObject CreatePitcher()
    {
        GameObject mobPlayerPrefab = (GameObject)Resources.Load("MobPlayer");
        MobParameter parameter = mobPlayerPrefab.GetComponent<MobParameter>();

        return mobPlayerPrefab;
    }

    // ���u���̃v���n�u�𐶐����A�`�[���N���X�ɓn��
    public GameObject CreateFielder()
    {
        GameObject mobPlayerPrefab = (GameObject)Resources.Load("MobPlayer");
        MobParameter parameter = mobPlayerPrefab.GetComponent<MobParameter>();

        return mobPlayerPrefab;
    }
}
