using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : ButtonManager
{
    protected override void OnClick(string buttonName)
    {
        if(buttonName.Equals("Exit"))
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}
