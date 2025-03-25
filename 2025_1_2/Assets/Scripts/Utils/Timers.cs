using UnityEngine;

public class Timers : MonoBehaviour
{
    private static Timers _instance;
    public static Timers Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Timers is null");
            }
            return _instance;
        }
    }

    [SerializeField] private float _gameTime;
    public float GameTime => _gameTime;
    [field: SerializeField]
    public bool IsGameDuring { get; set; } = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }   
    }

    private void Update()
    {
        if (IsGameDuring)
            _gameTime += Time.deltaTime;
    }

    public void StartTimer()
    {
        IsGameDuring = true;
    }

    public void StopTimer()
    {
        IsGameDuring = false;
    }
}
