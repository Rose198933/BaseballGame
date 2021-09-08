using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    // �I�������`�[���A�C�R��
    [SerializeField]
    private GameObject firstPlayer;
    [SerializeField]
    private GameObject secondPlayer;
    private Image image;

    // �I�������`�[���N���X
    [SerializeField]
    private Teams firstTeam;
    [SerializeField]
    private Teams secondTeam;

    public void SetFirst(Teams firstTeam)
    {
        this.firstTeam = firstTeam;
        SetIcon(firstPlayer, this.firstTeam);
    }

    public void SetSecond(Teams secondTeam)
    {
        this.secondTeam = secondTeam;
        SetIcon(secondPlayer, this.secondTeam);
    }

    private void SetIcon(GameObject player, Teams team)
    {
        image = player.GetComponent<Image>();
        image.sprite = team.GetIcon();
    }
}
