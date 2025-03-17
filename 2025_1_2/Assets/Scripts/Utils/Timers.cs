using UnityEngine;

public class Timers : MonoBehaviour
{
    [SerializeField] private float _gameTime;
    public float GameTime => _gameTime;

    private void Update()
    {
        _gameTime += Time.deltaTime;
    }
}
