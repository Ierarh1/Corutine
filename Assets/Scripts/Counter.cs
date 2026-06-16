using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterInputHandler _inputHandler;
   
    public event Action<int> CounterChanged;

    private float _delay = 0.5f;
    private int _startValue = 0;
    private int _stepValue = 1;
    
    private void Start()
    {
        StartCoroutine(Timer(_delay, _startValue, _stepValue));
    }

    private IEnumerator Timer(float delay, int value,int stepValue)
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(delay);

        while (true)
        {
            if (_inputHandler.IsRunningCoroutine == true)
            {
                CounterChanged?.Invoke(value);

                value += stepValue;
            }

            yield return wait;
        }
    }
}
