using System.Collections.Generic;
using UnityEngine;

public class SignalingSystem : MonoBehaviour
{
    [SerializeField] private AreaDetector _detector;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        _detector.Entered += OnRobberEntered;
        _detector.Exited += OnRobberExited;
    }

    private void OnDisable()
    {
        _detector.Entered -= OnRobberEntered;
        _detector.Exited -= OnRobberExited;
    }

    private void OnRobberEntered()
    {
        _alarm.Activate();
    }

    private void OnRobberExited()
    {
        _alarm.Deactivate();
    }
}