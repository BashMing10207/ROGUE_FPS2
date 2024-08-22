using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCR : MonoBehaviour
{
    public GameObject gam;
    public float size;
    public int cnt;
    void Start()
    {
        for(int i=0; i<cnt; i++)
        {
            for(int j=0; j<cnt; j++)
            {
                Instantiate(gam, new Vector3(i, 0,j) * size, Quaternion.identity,transform).name = "Tile"+j.ToString()+"_"+i.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
