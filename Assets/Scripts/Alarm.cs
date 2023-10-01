using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _changeSpeed;

    private const float _minVolume = 0;
    private const float _maxVolume = 1;
    private AudioSource _source;
    private Coroutine _currentVolumeChanging;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        StopCurrentVolumeChanging();
        _currentVolumeChanging = StartCoroutine(ChangingVolume(_maxVolume));
    }

    public void Deactivate()
    {
        StopCurrentVolumeChanging();
        _currentVolumeChanging = StartCoroutine(ChangingVolume(_minVolume));
    }

    private IEnumerator ChangingVolume(float targetVolume)
    {
        while (_source.volume != targetVolume)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, targetVolume, _changeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void StopCurrentVolumeChanging()
    {
        if (_currentVolumeChanging != null)
            StopCoroutine(_currentVolumeChanging);
    }
}