using UnityEngine;
[CreateAssetMenu(fileName ="GunType",menuName ="FUCK/SHit",order =0)]



public class GunSO : ScriptableObject
{
    public WpID ID;
    public ProjectileType projectileType;
    public bool isMulti=false,isAnimEvent=true;
    public int multi=1,ammo=7;
    public float damage,random;
    public AnimatorOverrideController gunAnime;
}
