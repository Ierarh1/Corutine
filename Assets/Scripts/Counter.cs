using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputHandler;
   
    public event Action<int> CounterChanged;

    private Coroutine _counterCoroutine;

    private float _delay = 0.5f;
    private int _value = 0;
    private int _stepValue = 1;
    
    private void Start()
    {
        _counterCoroutine = StartCoroutine(Timer());
    }

    private void OnEnable()
    {
        _inputHandler.MouseClicked += ToggleCounter;
    }

    private void OnDisable()
    {
        _inputHandler.MouseClicked -= ToggleCounter;
    }

    private void ToggleCounter()
    {
        if (_counterCoroutine == null)
        {
            _counterCoroutine = StartCoroutine(Timer());
        }
        else
        {
            StopCoroutine(_counterCoroutine);

            _counterCoroutine = null;
        }
    }

    private IEnumerator Timer()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(_delay);

        while (true)
        {
            _value += _stepValue;

            CounterChanged?.Invoke(_value);

            yield return wait;
        }
    }
}
