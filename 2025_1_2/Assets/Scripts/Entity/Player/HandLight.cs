using UnityEngine;

public class HandLight : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private bool _isTurned = false;

    private void Start()
    {
        _light?.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(Define.Keys.TurnHandLight))
        {
            _isTurned = !_isTurned; 
            _light.gameObject.SetActive(_isTurned);
        }
    }
}
