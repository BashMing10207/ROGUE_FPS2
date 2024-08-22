using Cum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SongMana : MonoBehaviour
{

    public bool[,] Markers;
    public AudioClip[] Sound;
    public float[] power = new float[(int)ASkill.last], powerMulti = new float[(int)ASkill.last];
    public int indexY=1,indexX =5;
    public float BPM = 120,Mspeed=0.9f,BPMMULTI=1;
    public ASkill[] skill;
    bool _playing;
    [SerializeField]
    private float cum=80;
    Coroutine _playMusicCor;


    private void Awake()
    {
       //Markers = new bool[indexX,indexY];
        GameMana.instance.songMana = this;
        Markers = GameMana.instance.ming.Markers;

    }
    private void Start()
    {
        GameMana.instance.ToggleMusicMaker();
        _playing = true;
    }
    public void PlayMusic()
    {
        _playing = !_playing;
        _playMusicCor = StartCoroutine(Corutine1(0));
    }

    public void StopMusic()
    {
        StopCoroutine(_playMusicCor);
    }
    IEnumerator Corutine1(int index)
    {
        if (!_playing)
        {
            yield break;
        }

        for (int i = 0; i < indexY; i++)
        {
            if (Markers[index, i])
            {
                StartCoroutine(PlaydSound(i));

                if (i <2)
                    GameMana.instance.uicr.Create(i);
            }
        }
        //print(index);
        yield return new WaitForSeconds(60 / BPM/BPMMULTI);

        StartCoroutine(Corutine1((index + 1) % indexX));
    }

    IEnumerator PlaydSound(int i)
    {
        yield return new WaitForSeconds(1);

        SoundMana.Instance.AudPlay(Sound[i]);
        if (i % 2 == 0)
        {
            GameMana.instance.EnemyMov[i / 2]?.Invoke();
        }
        powerMulti[i] = 1;
        power[i] = 2;
    }

    private void OnDestroy()
    {
        GameMana.instance.ming = new MarkerSk(Markers,Sound,skill);
    }
}


