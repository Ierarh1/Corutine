using UnityEngine;

public class CounterInputHandler : MonoBehaviour
{
    public bool IsRunningCoroutine { get; private set; } = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            IsRunningCoroutine = !IsRunningCoroutine;
        }
    }
}
