using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamIconController : MonoBehaviour
{
    // �`�[���f�[�^
    [SerializeField]
    private Teams teamData;

    [SerializeField]
    private Image image;

    public void GetImage()
    {
        image = this.GetComponent<Image>();
        image.sprite = teamData.GetIcon();
    }

    public void SetTeamData(Teams teamData)
    {
        this.teamData = teamData;
    }

    public Teams GetTeamData()
    {
        return this.teamData;
    }
}
