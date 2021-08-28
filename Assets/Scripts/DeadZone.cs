using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private UnityEvent DeadEvent;

    private void OnTriggerEnter(Collider other)
    {
        DeadEvent?.Invoke();
    }
}
