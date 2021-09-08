using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TeamSelectController : MonoBehaviour, IPointerClickHandler
{
    private TeamManager manager;

    public void OnPointerClick(PointerEventData pointer)
    {
        manager = GameObject.Find("TeamManager").GetComponent<TeamManager>();

        if(!FlagManager.instance.isTeamSelect)
        {
            manager.SetFirst(this.gameObject.GetComponent<TeamIconController>().GetTeamData());
            FlagManager.instance.isTeamSelect = true;
        }
        else
        {
            manager.SetSecond(this.gameObject.GetComponent<TeamIconController>().GetTeamData());
        }
    }
}
