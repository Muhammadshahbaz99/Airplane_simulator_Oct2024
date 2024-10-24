using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableDisable : MonoBehaviour
{
    [SerializeField] UnityEvent onEnable, onDisable = new UnityEvent();

    private void OnEnable()
    {
        onEnable.Invoke();
    }
    private void OnDisable()
    {
        onDisable.Invoke();
    }
}
