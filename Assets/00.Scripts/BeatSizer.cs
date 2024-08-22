using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSizer : MonoBehaviour
{
    public int index;
    void Update()
    {
        if(GameMana.instance.songMana.power[index] < 1)
        {
            GameMana.instance.songMana.power[index] = 0;
        }
        transform.localScale = Vector3.one * 4.5f * GameMana.instance.songMana.power[index];

    }
}
