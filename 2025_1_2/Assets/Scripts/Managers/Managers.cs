using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    public static Managers _instance;

    public Utility_Manager util = new();
    public Game_Manager game = new();

    public static Managers Instance
    {
        get
        {
            Init();

            return _instance;
        }
    }

    public static Utility_Manager Util { get { return Instance.util; } }
    public static Game_Manager Game {  get { return Instance.game; } }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("Stage_1");
        }
    }

    public static  void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
            }

            _instance = go.AddComponent<Managers>();

            DontDestroyOnLoad(go);
        }
    }
}
