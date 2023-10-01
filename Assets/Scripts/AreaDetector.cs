using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class AreaDetector : MonoBehaviour
{
    public event UnityAction Entered;
    public event UnityAction Exited;

    private void OnTriggerEnter(Collider other)
    {
        Entered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Exited?.Invoke();
    }
}