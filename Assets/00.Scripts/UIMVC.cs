using UnityEngine;
using UnityEngine.UI;

public class UIMVC : MonoBehaviour
{
    public float ming;
    public ProjectileType ttype;
    public RawImage img;
    public Vector3 Pos;
    private void OnEnable()
    {
        ming = 0;
        img.rectTransform.localScale = Vector3.one*2;
    }
    void Update()
    {
        ming += Time.deltaTime;
        img.rectTransform.position = Vector3.Lerp(Pos, new Vector3(960,1080/2,0)+(Pos- new Vector3(960, 1080 / 2, 0)) /30, ming);
        img.rectTransform.localScale = Vector3.Lerp(Vector3.one/4,Vector3.one*1.5f,ming);
        if (ming >= 1.25f)
        {
            GameMana.instance.pool.Get(ttype, gameObject);
        }
    }
}
