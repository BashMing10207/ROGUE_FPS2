using Cum;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ASkill
{
    Move,
    Pistol,
    ShotGun,
    SMG,
    LMG,
    RG,
    Cannon,
    Parry,
    last
}

namespace Cum
{
    public struct MarkerSt
    {
        public bool Markers;
        public AudioClip _clip;
    }
    public struct MarkerSk
    {
        public bool[,] Markers;
        public AudioClip[] clips;
        public ASkill[] skills;

        public MarkerSk(bool[,] a, AudioClip[] clip, ASkill[] skill)
        {
            Markers = a;
            clips = clip;
            skills = skill;
        }
    }
}

public class SoundMarker : MonoBehaviour
{
    public struct songTile
    {
        public bool Markers;
        public RectTransform _markerButtons;
        public Image _image;
    }

    public static MarkerSt[,] s_marker;

    RectTransform _rectTransform;
    public int indexX = 12, indexY = 5;
    //public static List<List<bool>> Markers = new List<List<bool>>();
    bool[,] Markers;
    public songTile[,] _tiles;
    public Transform MarkersPar;
    //List<List<RectTransform>> _markerButtons = new List<List<RectTransform>>();
    //List<List<Image>> _image = new List<List<Image>>();
    public GameObject buttonPrf;
    Vector2Int Pos;
    public Color[] colors;
    public Color emthycolor;
    public AudioSource audioSource;
    public float BPM = 120;

    Coroutine PlayMusicCor;
    public AudioClip[] Sound;
    public AudioClip failSOund;
    bool _playing = false;
    public TextMeshProUGUI notcountUi;
    //public static Action[] Audios; 
    public int NotCount;
    private void OnEnable()
    {

        _rectTransform = GetComponent<RectTransform>();
        //print(GameMana.instance.songMana);
        indexX = GameMana.instance.songMana.indexX;
        indexY = GameMana.instance.songMana.indexY;
        Initalize();
        NotCount = GameMana.instance.noteCount;
        Cursor.lockState = CursorLockMode.Confined;
    }


    void Initalize()
    {
        GameMana.instance.ming.Markers = new bool[indexX, indexY];
        _tiles = new songTile[indexX, indexY];

        //s_marker = new MarkerSt[indexX, indexY];

        Markers = new bool[indexX, indexY];

        for (int i = 0; i < indexX; i++)
        {
            for (int j = 0; j < indexY; j++)
            {
                _tiles[i, j]._markerButtons = Instantiate(buttonPrf, transform).GetComponent<RectTransform>();
                _tiles[i, j]._image = _tiles[i, j]._markerButtons.GetComponent<Image>();
                _tiles[i, j]._markerButtons.sizeDelta = new Vector2(_rectTransform.sizeDelta.x / indexX, _rectTransform.sizeDelta.y / indexY);
                _tiles[i, j]._markerButtons.anchoredPosition = new Vector2(_tiles[i, j]._markerButtons.sizeDelta.x * ((float)i + 0.5f), _tiles[i, j]._markerButtons.sizeDelta.y * -((float)j + 0.5f));

                //_markerButtons[i][j] = Instantiate(buttonPrf, transform).GetComponent<RectTransform>();
                //_image[i][j] = _markerButtons[i][j].GetComponent<Image>();
                //_markerButtons[i][j].sizeDelta = new Vector2(_rectTransform.sizeDelta.x / indexX, _rectTransform.sizeDelta.y / indexY);
                //_markerButtons[i][j].anchoredPosition = new Vector2(_markerButtons[i][j].sizeDelta.x * ((float)i + 0.5f), _markerButtons[i][j].sizeDelta.y * -((float)j + 0.5f));

            }
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (Inside(_rectTransform.position.x - _rectTransform.sizeDelta.x / 2, _rectTransform.position.x + _rectTransform.sizeDelta.x / 2, Input.mousePosition.x)
                && Inside(_rectTransform.position.y - _rectTransform.sizeDelta.y / 2, _rectTransform.position.y + _rectTransform.sizeDelta.y / 2, Input.mousePosition.y))
            {                
                Pos = (new Vector2Int(indexX + Mathf.CeilToInt((Input.mousePosition.x - _rectTransform.position.x - _rectTransform.sizeDelta.x / 2) / (_rectTransform.sizeDelta.x / indexX)) - 1,
                    -Mathf.CeilToInt((Input.mousePosition.y - _rectTransform.position.y - _rectTransform.sizeDelta.y / 2) / (_rectTransform.sizeDelta.y / indexY))));

                if(_tiles[Pos.x, Pos.y].Markers == true || NotCount > 0)
                {
                    NotCount += (_tiles[Pos.x, Pos.y].Markers == true) ? 1 : -1;
                    notcountUi.text="NoteCount: "+NotCount.ToString();
                _tiles[Pos.x, Pos.y].Markers = !_tiles[Pos.x, Pos.y].Markers;
                
                GameMana.instance.songMana.Markers[Pos.x, Pos.y] = !GameMana.instance.songMana.Markers[Pos.x, Pos.y];
                // Markers[Pos.x, Pos.y] = !Markers[Pos.x, Pos.y];
                _tiles[Pos.x, Pos.y]._image.color = (_tiles[Pos.x, Pos.y].Markers == true) ? colors[Pos.y] : emthycolor;
                audioSource.PlayOneShot(GameMana.instance.songMana.Sound[Pos.y]);
                }
                else
                {
                    audioSource.PlayOneShot(failSOund);
                }
            }
            //s_marker[Pos.x, Pos.y].Markers = !s_marker[Pos.x, Pos.y].Markers;

        }
    }

    bool Inside(float a, float b, float c)
    {
        return (a < c) && (c < b);
    }

    //public void PlayMusic()
    //{
    //    musicWindow.SetActive(!musicWindow.activeSelf);
    //    GameMana.instance.songMana.PlayMusic();
    //}

    private void OnDisable()
    {
        foreach (Transform ch in GetComponentsInChildren<Transform>())
        {
            if(ch!= transform)
            Destroy(ch.gameObject);
        }
        Cursor.lockState = CursorLockMode.Locked;
    }
}
