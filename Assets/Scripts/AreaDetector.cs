using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class AreaDetector : MonoBehaviour
{
    public event UnityAction<Robber> Entered;
    public event UnityAction<Robber> Exited;

    private void OnTriggerEnter(Collider other)
    {
        Robber robber;

        if (other.TryGetComponent(out robber) == true)
            Entered?.Invoke(robber);
    }

    private void OnTriggerExit(Collider other)
    {
        Robber robber;

        if (other.TryGetComponent(out robber) == true)
            Exited?.Invoke(robber);
    }
}