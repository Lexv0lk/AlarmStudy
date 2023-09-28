using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _changeSpeed;

    private float _maximalVolume = 1.0f;
    private float _minimalVolume = 0f;
    private IEnumerator _currentVolumeChanging;

    public void Activate()
    {
        StopVolumeChanging();
        StartCoroutine(ChangeVolume(_maximalVolume, _maximalVolume));
    }

    public void Deactivate()
    {
        StopVolumeChanging();
        StartCoroutine(ChangeVolume(-_maximalVolume, _minimalVolume));
    }

    private void StopVolumeChanging()
    {
        if (_currentVolumeChanging != null)
        {
            StopCoroutine(_currentVolumeChanging);
            _currentVolumeChanging = null;
        }
    }

    private IEnumerator ChangeVolume(float delta, float targetValue)
    {
        while (_source.volume != targetValue)
        {
            _source.volume += delta * Time.deltaTime;
            yield return null;
        }
    }
}