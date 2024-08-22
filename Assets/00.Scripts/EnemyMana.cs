using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMana : MonoSingleton<EnemyMana>
{
    public LayerMask la;
    public int maxweight = 10,weight=10;
    public List<EnemySO> enemyTypes = new List<EnemySO>();

    private void Start()
    {
        GameMana.instance.enemymana = this;
    }

    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.V))
        {
            SpawnEnemy(10, 10);
        }
    }

    public void SpawnEnemy(int x,int y)
    {
        RaycastHit hit;
        weight = maxweight;

        if(weight < 0)
        {
            return;
        }
        while(weight > 1)
        {
            if(Physics.Raycast(new Vector3(8 * Random.Range(0, x), 60, 8 * Random.Range(0, y)), Vector3.down, out hit,1024, la))
            {
                int num = Random.Range(0, enemyTypes.Count);

                if(enemyTypes[num].weight <= weight)
                {
                    weight -= enemyTypes[num].weight;
                    GameMana.instance.enPool.Give(enemyTypes[num].enemyType, hit.point + Vector3.up * 1f).transform.position = hit.point+Vector3.up*1f;
                }

            }
        }
        //GameMana.instance.enPool.Give()
    }
}
