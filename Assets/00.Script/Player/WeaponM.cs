
using UnityEngine;

public enum gunType
{
    Rev,
    SHot,
    EG
}
public class WeaponM : MonoBehaviour
{
    [SerializeField]
    ParticleSystem[] _gunparticle;
    [SerializeField]
    KeyCode[] _keys;
    [SerializeField]
    int wpcount;
    [SerializeField]
    Animator anime;

    RaycastHit _ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(GameMana.instance.maincam.ScreenPointToRay(Input.mousePosition),out _ray))
        {

        transform.LookAt(new Vector3(_ray.point.x,transform.position.y, _ray.point.z));
        }

        for(int i = 0; i < wpcount;i++)
        {
            if (Input.GetKey(_keys[i]) && (GameMana.instance.songMana.power[1 + i] > 0.2f))
            {
                GameMana.instance.songMana.power[i+1] = 0;
                anime.SetTrigger("Shot");
                anime.SetInteger("WpType", i);
            }

            if (Input.GetKeyDown(_keys[i]) && (GameMana.instance.songMana.power[1+i] <= 0.2f && GameMana.instance.songMana.power[1 + i] >0.12f))
            {
            print("Perfect!");
            anime.SetTrigger("Shot");
            anime.SetInteger("WpType", i);
            GameMana.instance.songMana.power[i + 1] = 0;
            }
        }


    }

    public void Shot(gunType type) {
        _gunparticle[(int)type].Play();
    }

}
