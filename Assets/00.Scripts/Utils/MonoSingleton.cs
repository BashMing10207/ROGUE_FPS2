using UnityEngine;
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance is null) _instance = Initialize();
            return _instance;
        }
    }
    private static T Initialize()
    {
        GameObject gameObject = new GameObject();
        T result = gameObject.AddComponent<T>();
        return result;
    }

    protected virtual void Awake()
    {
        if (_instance is not null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this as T;
        name = "Singleton_" + typeof(T).Name;
    }
    protected virtual void OnDestroy()
    {
        if(_instance == this)
        {
            _instance = null;
        }
    }
}