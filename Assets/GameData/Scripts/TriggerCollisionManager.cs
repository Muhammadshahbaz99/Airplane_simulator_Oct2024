using UnityEngine;
using UnityEngine.Events;

public class TriggerCollisionManager : MonoBehaviour
{
    [Tooltip("Events will work only when one of ther other name or other tag matches with the other collider")]
    [SerializeField] string otherTag, otherName;
    [SerializeField] UnityEvent onTriggerEnter, onColissionEnter = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name==otherName || other.gameObject.tag==otherTag)
            onTriggerEnter.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains(otherName) || other.gameObject.tag.Contains(otherTag))
            onColissionEnter.Invoke();
    }
}
