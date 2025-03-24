using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    private static PlayerMoney _instance;
    public static PlayerMoney Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("PlayerMoney is null");
            }

            return _instance;
        }
    }

    [Header("�÷��̾� ������")]
    [SerializeField] private int _money;
    public int Money => _money;

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

    public void AddMoney(int amount)
    {
        _money += amount;
        Debug.Log($"ȹ���� ��: {amount}");
    }

    public void SpendMoney(int amount)
    {
        if (_money >= amount)
        {
            _money -= amount;
            Debug.Log($"���� ��: {_money}");
        }
    }
}
