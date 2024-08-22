using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    [SerializeField]
    Animator anime;
    [SerializeField]
    int[] stageCounts;
    public int stage;
    public GameObject rewords,endOBJ;

    public string SceneName;
    // Start is called before the first frame update
    void Awake()
    {
        GameMana.instance.stg = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change()
    {
        anime.SetTrigger("Set");

        if (stage < 10)
        {
            rewords.SetActive(true);
        }
        else
        {
            endOBJ.SetActive(true);
            GameMana.instance.songMana.PlayMusic();
        }
    }

    public void NextStage()
    {
        stage++;
        anime.SetInteger("Stage", stage);

        anime.SetInteger("Rand", Random.Range(0, stageCounts[stage]));
        anime.SetTrigger("Next");

        if(stage > 9)
        {
            
        }
    }
}
