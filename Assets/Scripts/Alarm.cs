using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _changeSpeed;

    private const float _maxVolume = 1f;
    private const float _minVolume = 0f;
    private float _targetVolume = _minVolume;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_source.volume == _targetVolume)
            return;

        _source.volume = Mathf.MoveTowards(_source.volume, _targetVolume, _changeSpeed * Time.deltaTime);
    }

    public void Activate() => _targetVolume = _maxVolume;

    public void Deactivate() => _targetVolume = _minVolume;
}