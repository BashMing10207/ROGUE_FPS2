using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum WpID
{
    Hand,
    Pis,
    Rev,
    SHot,
    Dino,
    Dino2,
    Man,
    Man2,
    Drone,
    Drone2
}

public class Gun : MonoBehaviour
{
    //public AnimatorOverrideController controller,breakC,defaultC;
    //public Animator viewModel;
    //public ParticleSystem[] par;
    //public ParticleSystem breakpt;
    //public int wpnum = 0, wpcount = 3;
    //public GunSO[] guns;
    //public ProjectileType[] bulletTypes;
    //Vector3 localspeed;
    //public KeyCode ming,altMing;
    //public int dirr = 1;
    //int xming=1;
    //public bool isWpHand = true;
    //public bool[] GUnActived;
    //public int ammo;
    //public UnityEvent<float> ChanageAmmo;
    //public bool isWpChangeAble=true;
    //public bool perfactSgh=false;
    //void Awake()
    //{
    //    //ChanageAmmo.AddListener(ShootAction);
    //}

    //void OnEnable()
    //{

    //    if(dirr == 1)
    //    {
    //        xming = -1;
    //    }
    //    Initming();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (isWpHand)
    //    {
    //        if (isWpChangeAble)
    //        {
    //            bool ischangeToggled = false;
    //            if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
    //            {
    //                ischangeToggled = true;
    //                transform.GetChild((int)guns[wpnum].ID).gameObject.SetActive(false);

    //                do
    //                {
    //                    wpnum = ((wpnum + (int)Input.GetAxisRaw("Mouse ScrollWheel")) % wpcount);
    //                    if (wpnum < 0) { wpnum = wpcount - 1; }
    //                    if (wpnum < wpcount) { wpnum = 0; }
    //                }
    //                while (GUnActived[wpnum]);
    //                //viewModel.SetInteger("WeaponNum",wpnum);
    //            }
    //            if (Input.GetKeyDown(KeyCode.Alpha1))
    //            {
    //                ischangeToggled = true;
    //                wpnum = 0;
    //            }
    //            if (Input.GetKeyDown(KeyCode.Alpha2))
    //            {
    //                ischangeToggled = true;
    //                wpnum = 1;
    //            }
    //            if ((Input.GetKeyDown(KeyCode.Alpha3)))
    //            {
    //                ischangeToggled = true;
    //                wpnum = 2;
    //            }
    //            if (Input.GetKeyDown(KeyCode.Alpha4))
    //            {
    //                ischangeToggled = true;
    //                wpnum = 3;
    //            }
    //            if(ischangeToggled)
    //            Initming();
    //        }
            
    //    }
    //    else // SOLID를 지키지 않은 초심으로 돌아와버린 코드... 왼손코드임. 죄송합니다.
    //    {

    //        //viewModel.SetBool("Break", Input.GetKeyDown(altMing));
    //        //viewModel.SetBool("Perfact", GameMana.instance.songMana.power[dirr] > 0 && Input.GetKeyDown(altMing));


    //        if (Input.GetKeyDown(altMing))
    //        {
    //            if(viewModel.runtimeAnimatorController != breakC)
    //            {
    //                transform.GetChild((int)guns[wpnum].ID).gameObject.SetActive(false);
    //                viewModel.runtimeAnimatorController = breakC;
    //            }

    //            if(wpnum ==0&&viewModel.runtimeAnimatorController != defaultC)
    //            {
    //                viewModel.runtimeAnimatorController = defaultC;
    //            }
    //        }
    //        if (Input.GetKeyDown(altMing))
    //        {
    //            GameMana.instance.songMana.power[dirr] = 0;
    //        }
    //    }

    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        viewModel.SetTrigger("Reload");
    //    }

    //}

    //public void Resett()
    //{
        
    //}

    //public void PlayAudio(AudioClip clip)
    //{
    //    SoundMana.Instance.AudPlay(clip);
    //}
    //public void Effect()
    //{
    //    transform.GetChild((int)guns[wpnum].ID).gameObject.SetActive(false);
    //    wpnum = 0;
    //    breakpt.Play();
    //}

    //public void Shoot()
    //{
    //    //ChanageAmmo.Invoke(ammo / guns[wpnum].ammo);
        
    //    //if (fuckfuckming)
    //    //    PerfactShoot();
    //    //else
    //       ShootAction();
    //}

    //public void ShootAction()
    //{
    //    if (ammo > 1)
    //    {
    //        ammo--;
    //        if (guns[wpnum].isAnimEvent)
    //        {

    //            if (guns[wpnum].isMulti)
    //            {
    //                for (int i = 0; i < guns[wpnum].multi; i++)
    //                {
    //                    //GameMana.instance.pool.Give(guns[wpnum].projectileType, par[wpnum].transform, guns[wpnum].random);
    //                    //GameMana.instance.pool.Give(guns[wpnum].projectileType, GameMana.instance.maincam.transform, guns[wpnum].random);
    //                }
    //            }
    //            else
    //            {
    //                //GameMana.instance.pool.Give(guns[wpnum].projectileType, par[wpnum].transform);
    //            }
    //            par[wpnum].Play();
    //        }
    //    }
    //    else
    //    {
    //        if (isWpHand)
    //        {
    //            if(isWpChangeAble)
    //            viewModel.SetTrigger("Reload");
    //            ammo = guns[wpnum].ammo;
    //        }
    //        else
    //        {
    //            if (viewModel.runtimeAnimatorController != defaultC)
    //            {
    //                transform.GetChild((int)guns[wpnum].ID).gameObject.SetActive(false);
    //                wpnum = 0;
    //                Initming();
    //            }

    //        }
    //    }
    //}

    //public void PerfactShoot()
    //{
       
    //    if (guns[wpnum].isMulti)
    //    {
    //        for (int i = 0; i < guns[wpnum].multi; i++)
    //        {
    //            //GameMana.instance.pool.Give(guns[wpnum].projectileType, par[wpnum].transform, guns[wpnum].random);
    //            //GameMana.instance.pool.Give(guns[wpnum].projectileType, GameMana.instance.maincam.transform, guns[wpnum].random);
    //        }
    //    }
    //    else
    //    {
    //        //GameMana.instance.pool.Give(guns[wpnum].projectileType, par[wpnum].transform);
    //    }
    //    par[wpnum].Play();
    //}
    //public void ReloadG()
    //{
    //    GameMana.instance.cameraAnime.SetTrigger("Perfact");
    //    ammo = guns[wpnum].ammo;
    //    //장전도 액션화 해서 스킬추가 해야디...
    //    //ChanageAmmo.Invoke(ammo / guns[wpnum].ammo);
    //    //viewModel.SetFloat("Ammo", ammo / guns[wpnum].ammo);
    //}

    //public void Initming()
    //{
    //    //transform.GetChild((int)guns[wpnum].ID).gameObject.SetActive(false);
    //    viewModel.runtimeAnimatorController = guns[wpnum].gunAnime;
    //    transform.GetChild((int)guns[wpnum].ID).gameObject.SetActive(true);
    //    viewModel.Play("In", 1);
    //    ammo = guns[wpnum].ammo;
    //    //ChanageAmmo.Invoke(ammo / guns[wpnum].ammo);
    //}

    //public void SetWP(GunSO gsos)
    //{
    //    wpnum = (int)gsos.ID;
    //    viewModel.SetTrigger("PerfactT");
    //    //Initming();
    //}

    //public void HealHp(float heal)
    //{
    //    GameMana.instance.playerHP.Damage(-heal);
    //}
}
