using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TeamDatabase", menuName = "CreateTeamDatabase")]
public class TeamDatabase : ScriptableObject
{
    [SerializeField]
    private List<Teams> teamList = new List<Teams>();

    public List<Teams> GetTeamList()
    {
        return teamList;
    }
}
