using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Detector : MonoBehaviour
{
    public UnityAction<GameObject> Detected;

    private void OnTriggerEnter(Collider other)
    {
        Detected?.Invoke(other.gameObject);
    }
}