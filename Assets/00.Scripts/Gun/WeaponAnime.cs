using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public enum WeaponParamsF
{
    AtSp,
    Ammo,
    X,
    Y,
    Z,
    MX,
    MY,
    end
}
public enum WeaponParamsB
{
    Fire,
    Walking,
    Sliding,
    end
}

public class WeaponAnime : MonoBehaviour
{
    public Animator viewModel;
    
    public int[] wpAnimHashB;
    public int[] wpAnimHashF;
    public int[] woAnimHashT;

    [SerializeField]
    float _xSpeedMulti=2, _ySpeedMulti=2,_zSpeedMulti=2, _xRotMulti=2,_yRotMulti=2;

    // Start is called before the first frame update
    void Start()
    {
        wpAnimHashB = new int[(int)WeaponParamsB.end];
        wpAnimHashF = new int[(int)WeaponParamsF.end];

        for (int i = 0; i< (int)WeaponParamsB.end; i++)
        {
            //wpAnimHashB[i] = viewModel.GetFloat(((WeaponParamsB)i).ToString()).GetHashCode();
            wpAnimHashB[i] = Animator.StringToHash(((WeaponParamsB)i).ToString());
        }
        for(int i = 0; i< (int)WeaponParamsF.end; i++)
        {
            // wpAnimHashF[i] = viewModel.GetFloat(((WeaponParamsF)i).ToString()).GetHashCode();
            wpAnimHashF[i] = Animator.StringToHash(((WeaponParamsF)i).ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {

        //viewModel.SetFloat(wpAnimHashF[(int)WeaponParamsF.AtSp] GameMana.instance.AttackSpeed * GameMana.instance.AttackSpeedMulti);
        viewModel.SetBool(wpAnimHashB[(int)WeaponParamsB.Fire], RPlayerMana.Instance.playerInput.isFire);

        Vector3 localspeed = transform.InverseTransformVector(RPlayerMana.Instance.playerMovement.rigidbody.velocity);

        viewModel.SetFloat(wpAnimHashF[(int)WeaponParamsF.X], Mathf.Clamp(localspeed.x / 15 * _xSpeedMulti,-1,1), 0.5f, Time.deltaTime * 2);
        viewModel.SetFloat(wpAnimHashF[(int)WeaponParamsF.Y], Mathf.Clamp01(localspeed.y / 30*_ySpeedMulti + 0.5f), 0.25f, Time.deltaTime * 5);
        viewModel.SetFloat(wpAnimHashF[(int)WeaponParamsF.Z], Mathf.Clamp(localspeed.z / 15*_zSpeedMulti,-1,1), 0.5f, Time.deltaTime * 2);
        viewModel.SetFloat(wpAnimHashF[(int)WeaponParamsF.MX], Mathf.Clamp(Input.GetAxis("Mouse X") * _xRotMulti,-1,1), 0.8f, Time.deltaTime * 2);
        viewModel.SetFloat(wpAnimHashF[(int)WeaponParamsF.MY], Mathf.Clamp01(Input.GetAxis("Mouse Y")/2+ 0.5f), 0.8f, Time.deltaTime * 2);

        viewModel.SetBool(wpAnimHashB[(int)WeaponParamsB.Walking], RPlayerMana.Instance.playerMovement._isCanJump && (RPlayerMana.Instance.playerInput.movement != Vector2.zero));
        //viewModel.SetFloat("Ammo", 1 - (float)ammo / guns[wpnum].ammo);
        //print(1 - (float)ammo / guns[wpnum].ammo);

        //if (Input.GetKeyDown(ming) || Input.GetKeyDown(altMing))
        //     GameMana.instance.songMana.power[dirr] = 0;
        // viewModel.SetBool("Charge", Input.GetKey(KeyCode.Mouse1));
        //viewModel.SetBool(wpAnimHashB[WeaponParamsB.Sliding], RPlayerMana.Instance.playerMovement.isSliding);
        //viewModel.SetFloat("X", localspeed.x / 15 * xming, 0.5f, Time.deltaTime * 2);
        //viewModel.SetFloat("Y", Mathf.Clamp01(-localspeed.y / 30 + 0.5f), 0.5f, Time.deltaTime * 2);
        //viewModel.SetFloat("Z", localspeed.z / 15, 0.5f, Time.deltaTime * 2);

    }
}
