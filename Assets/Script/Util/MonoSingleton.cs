using UnityEngine; 

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour 
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(T)) as T;

                if (_instance == null)
                    _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
            }

            //TODO : 임시 주석 처리
            //DontDestroyOnLoad(_instance.gameObject);

            return _instance;
        }
    }

    protected void Awake()
    {
        _instance = this.transform.GetComponent<T>();
        Init();
    }
    protected virtual void Init() { }
    public virtual void Destroy() { Destroy(this); }
}