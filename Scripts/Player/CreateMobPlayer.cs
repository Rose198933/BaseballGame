using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMobPlayer : MonoBehaviour
{

    // モブ投手のプレハブを生成し、チームクラスに渡す
    public GameObject CreatePitcher()
    {
        GameObject mobPlayerPrefab = (GameObject)Resources.Load("MobPlayer");
        MobParameter parameter = mobPlayerPrefab.GetComponent<MobParameter>();

        return mobPlayerPrefab;
    }

    // モブ野手のプレハブを生成し、チームクラスに渡す
    public GameObject CreateFielder()
    {
        GameObject mobPlayerPrefab = (GameObject)Resources.Load("MobPlayer");
        MobParameter parameter = mobPlayerPrefab.GetComponent<MobParameter>();

        return mobPlayerPrefab;
    }
}
