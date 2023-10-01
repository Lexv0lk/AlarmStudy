using UnityEngine;

public class SignalingSystem : MonoBehaviour
{
    [SerializeField] private AreaDetector _detector;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        _detector.Entered += OnEntered;
        _detector.Exited += OnExited;
    }

    private void OnDisable()
    {
        _detector.Entered -= OnEntered;
        _detector.Exited -= OnExited;
    }

    private void OnEntered(Robber robber)
    {
        _alarm.Activate();
    }

    private void OnExited(Robber robber)
    {
        _alarm.Deactivate();
    }
}