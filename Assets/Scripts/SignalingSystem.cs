using System.Collections.Generic;
using UnityEngine;

public class SignalingSystem : MonoBehaviour
{
    [SerializeField] private Detector _detector;
    [SerializeField] private Alarm _alarm;

    private List<GameObject> _objectsInside = new List<GameObject>();

    private void OnEnable()
    {
        _detector.Detected += OnObjectDetected;
    }

    private void OnDisable()
    {
        _detector.Detected -= OnObjectDetected;
    }

    private void OnObjectDetected(GameObject passedObject)
    {
        if (_objectsInside.Contains(passedObject))
            _objectsInside.Remove(passedObject);
        else
            _objectsInside.Add(passedObject);

        if (_objectsInside.Count == 0)
            _alarm.Deactivate();
        else if (_objectsInside.Count == 1)
            _alarm.Activate();
    }
}