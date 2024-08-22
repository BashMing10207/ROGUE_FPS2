using Unity.AI.Navigation;
using UnityEngine;

public class NavUpdate : MonoBehaviour
{
    public NavMeshSurface nav;
    public int addWeight=5;
    // Start is called before the first frame update
    void Start()
    {
        GameMana.instance.navUpdate = this;
    }

    public void Baker()
    {
        Invoke(nameof(ming),3f);
    }

    void ming()
    {
        nav.BuildNavMesh();
        GameMana.instance.enemymana.maxweight += addWeight;
        GameMana.instance.enemymana.SpawnEnemy(10,10);
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            //Baker();
        }
    }
}
