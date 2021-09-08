using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoneSelect : MonoBehaviour, IPointerClickHandler
{
    Material material;
    private bool isSelect = false;
    private Color initColor;

    private HittingSelect hitSelect;

    void Start()
    {
        this.material = this.GetComponent<MeshRenderer>().material;
        hitSelect = GameObject.Find("HittingSelectManager").GetComponent<HittingSelect>();
    }

    // ストライクゾーンの選択
    public void OnPointerClick(PointerEventData pointerData)
    {
        if(!this.isSelect)
        {
            this.initColor = material.color;
            Color changeColor = new Color(0.5f, 0, 0);
            material.color = changeColor;
            this.isSelect = true;

            // オブジェクト名から番号を取得して、HittingSelectに渡す
            string objName = this.gameObject.name;
            string strikeNum = objName.Replace("Strike", "");
            int selectCourseNum = int.Parse(strikeNum);
            hitSelect.GetSelectZone(selectCourseNum);
        }
        else
        {
            material.color = initColor;
            this.isSelect = false;
        }
    }
}
