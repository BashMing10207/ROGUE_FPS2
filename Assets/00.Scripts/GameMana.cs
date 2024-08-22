using Cum;
using System;
using UnityEngine;

public class GameMana : MonoBehaviour
{
    public static GameMana instance;

    public Pool pool;

    public int noteCount = 18,NoteCOuntY = 3,NoteCOuntX=5;

    public EnPool enPool;

    public MoveMIng mov;

    public Camera maincam;

    public EnemyMana enemymana; 

    public Gun gun;

    public Animator viewModel;

    public float AttackSpeed=1,AttackSpeedMulti=1;
    public float AttackTime;

    public MarkerSk ming = new MarkerSk();
    public Action[] EnemyMov = new Action[5];
    public SongMana songMana;
    public GameObject musicWindow;
    public UICR uicr;

    public ParticleSystem par;

    public float speed = 10;

    public int EnemyCount = 0;

    public SkillMana skill;

    public int NoteCount;

    public NavUpdate navUpdate;

    public Gun rightHand;

    public PlayerHP playerHP;

    public Stage stg;

    public Animator cameraAnime;
    private void Awake()
    {
        instance = this; 
        maincam = Camera.main;
        //DontDestroyOnLoad(gameObject);
        ming.Markers = new bool[99, 99];

    }


    public void ToggleMusicMaker()
    {
        musicWindow.SetActive(!musicWindow.activeSelf);
        GameMana.instance.songMana.PlayMusic();
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
            //songMana.PlayMusic();

        //if (Input.GetKeyDown(KeyCode.O))
           // musicWindow.SetActive(!musicWindow.activeSelf);

        for (int i = 0; i < songMana.power.Length; i++)
        {
            if (songMana.power[i] < 0)
            {
                songMana.power[i] = 0;
            }
            else
            {
                songMana.power[i] -= Time.deltaTime*2.5f;
            }
        }

        if(AttackSpeed > 1)
        {
            if(AttackTime >= 0)
            {
                AttackTime -= Time.deltaTime;
            }
            else
            {
                AttackSpeed = 1;
            }
        }

    }
}
