using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    private float _delay = 0.5f;
    private int _startValue = 0;
    private int _stepValue = 1;

    private bool _isRunningCoroutine = true;

    void Start()
    {
        StartCoroutine(Counter(_delay, _startValue, _stepValue));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _isRunningCoroutine = !_isRunningCoroutine;
        }
    }

    private IEnumerator Counter(float delay, int value,int stepValue)
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(delay);

        while (true)
        {
            if (_isRunningCoroutine == true)
            {
                DisplayCounter(value);

                value += stepValue;
            }

            yield return wait;
        }
    }

    private void DisplayCounter(int value)
    {
        _text.text = value.ToString();
    }
}
