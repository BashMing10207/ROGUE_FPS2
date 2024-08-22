
using UnityEngine;

public class GunEn : EnemyBase
{
    public ProjectileType bulletType;
    public Transform shootPos;
    public void Fire()
    {
        //shootPos.LookAt(GameMana.instance.mov.transform.position);
        Vector3 aa = _player.position - transform.position;
        if (new Vector3(aa.x, 0, aa.z) != Vector3.up && new Vector3(aa.x, 0, aa.z) != Vector3.down)
            transform.rotation = Quaternion.LookRotation(new Vector3(aa.x, 0, aa.z), Vector3.up);
        shootPos.LookAt(GameMana.instance.maincam.transform.position);
        GameMana.instance.pool.Give(bulletType,shootPos);
    }
}
