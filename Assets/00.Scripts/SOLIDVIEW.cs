using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SOLIDVIEW : MonoBehaviour
{
    public Image img;



    public void Change(float ammo)
    {
        img.fillAmount = ammo;
    }
}
