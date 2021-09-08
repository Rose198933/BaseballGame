using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public ButtonManager instance;

    public void OnClick()
    {
        if(instance == null)
        {
            instance = this;
        }

        instance.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string buttonName)
    {

    }
}
