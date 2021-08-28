using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _startEvent;

    void Start()
    {
        _startEvent?.Invoke();
    }
}
    