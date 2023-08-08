using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardManager : MonoBehaviour
{
    public void GetKeyData()
    {
        UserData.instance.FillText(this.gameObject.name);
    }

    public void SPACE()
    {
        UserData.instance.FillText(" ");
    }


}
