using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private GameObject _startMessage;
    
    private int _currentValue;

    private void Start()
    {
        GameplayManager.Instance.OnStartGame += Setup;
    }

    private void Setup()
    {
        _counter.gameObject.SetActive(true);
        _startMessage.SetActive(false);
    }

    public void UpdateCounter()
    {
        _currentValue++;
        _counter.text = $"{_currentValue}";
    }
}
