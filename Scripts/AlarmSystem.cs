using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    private const float VolumeMax = 1f;
    private const float VolumeMin = 0f;

    [SerializeField] private float _step;
    [SerializeField] private float _delay;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;
    private AudioSource _audio;
    private float _volumeAlarm;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        _audio = GetComponent<AudioSource>();
    }

    public void SetupModeAlarm(bool isThief)
    {
        if (isThief)
        {
            _volumeAlarm = VolumeMax;
            _audio.Play();
            StopChangeVolue();
            RestartChangeVolue();
        }
        else
        {
            _volumeAlarm = VolumeMin;
            StopChangeVolue();
            RestartChangeVolue();
        }

        if (_audio.volume == VolumeMin)
        {
            StopCoroutine(ChangeVolue());
            _audio.Stop();
        }
    }

    public void RestartChangeVolue()
    {
        _coroutine = StartCoroutine(ChangeVolue());
    }

    public void StopChangeVolue()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator ChangeVolue()
    {
        while (_audio.volume != _volumeAlarm)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _volumeAlarm, _step);
            yield return _wait;
        }
    }
}


