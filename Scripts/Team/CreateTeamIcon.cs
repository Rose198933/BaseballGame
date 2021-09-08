using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTeamIcon : MonoBehaviour
{
    // チームセレクト画面全体
    [SerializeField]
    private GameObject display;
    // 画面の高さ
    private float height;
    // 画面の幅
    private float width;
    // チームアイコン
    [SerializeField]
    private GameObject teamIcon;
    // チームアイコンの高さ
    private float iconHeight = 400;
    // チームアイコンの幅
    private float iconWidth = 400;
    // チームアイコンの数
    private int iconNumber;
    // アイコン間の幅、また画面端との幅
    private float iconSpace = 40;

    // チームデータベース（チーム数を取得するため）
    [SerializeField]
    private TeamDatabase database;
    private List<Teams> teamList;

    [SerializeField]
    private GameObject canvas;

    void Start()
    {
        teamList = database.GetTeamList();
        IconSet();
    }

    // チームアイコンを配置する
    private void IconSet()
    {
        height = display.GetComponent<RectTransform>().sizeDelta.y;
        width = display.GetComponent<RectTransform>().sizeDelta.x;
        iconNumber = teamList.Count;
        iconHeight = teamIcon.GetComponent<RectTransform>().sizeDelta.y;
        iconWidth = teamIcon.GetComponent<RectTransform>().sizeDelta.x;

        // 一列のアイコンの最大数を5に設定
        // 現状チーム数は最大10とする（5 × 2）
        float firstRowPosY = -(iconSpace + iconHeight / 2);
        float secondRowPosY = firstRowPosY * 2 - iconHeight / 2;

        for (int i = 0; i < teamList.Count; i++)
        {
            Vector3 teamPos;
            if (i < (iconNumber / 2))
            {
                float posX = -(iconWidth / 2 * ((iconNumber / 2 - 1) - i * 2) + (iconSpace * ((iconNumber / 2 - 3) - i)));
                teamPos = new Vector3(posX, firstRowPosY, 0);
            }
            else
            {
                float posX = -(iconWidth / 2 * ((iconNumber / 2 * 3 - 1) - i * 2) + (iconSpace * ((iconNumber - 3) - i)));
                teamPos = new Vector3(posX, secondRowPosY, 0);
            }

            // アイコンフレームを生成し、インスタンス化
            GameObject iconFrame = (GameObject)Resources.Load("TeamIconFramework");
            iconFrame.GetComponent<TeamIconController>().SetTeamData(teamList[i]);
            iconFrame.GetComponent<TeamIconController>().GetImage();
            GameObject instance = Instantiate(iconFrame, teamPos, Quaternion.identity);

            // インスタンスをCanvasに設置
            instance.transform.SetParent(canvas.transform, false);
        }

        // アイコンを並べたときの画面端から端までの長さ（あとでtry-catchに変更予定）
        float totalWidth;

        if(iconSpace > 5)
        {
            totalWidth = 5 * (iconSpace + iconWidth) + iconSpace;
        }
        else
        {
            totalWidth = iconNumber * (iconSpace + iconWidth) + iconSpace;
        }

        if(totalWidth > width)
        {
            Debug.Log("オーバー！");
        }
    }
}
