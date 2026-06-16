using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterChanged += DisplayTimer;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= DisplayTimer;
    }

    public void DisplayTimer(int value)
    {
        _text.text = value.ToString();
    }
}