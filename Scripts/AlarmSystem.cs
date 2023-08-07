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
    [SerializeField] private float _setback;

    private WaitForSeconds _timePause;
    private AudioSource _audio;
    private float _volumeAlarm;
    private bool _isWorkToIncrease;
    private bool _isIEnumeratorWork;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _timePause = new WaitForSeconds(_setback);
    }

    public void SetupModeAlarm(int countThiefs)
    {
        if (_isWorkToIncrease == false && countThiefs >= 1)
        {
            _isWorkToIncrease = true;
            _volumeAlarm = VolumeMax;
            _audio.Play();
        }

        if (countThiefs <= 0)
        {
            _volumeAlarm = VolumeMin;
            _isWorkToIncrease = false;
        }

        StartChangeVolue();

        if (_audio.volume == VolumeMin)
        {
            StopCoroutine(ChangeVolue());
            _audio.Stop();
            _isIEnumeratorWork = false;
        }
    }

    private void StartChangeVolue()
    {
        if ((_isIEnumeratorWork == false && _audio.volume != VolumeMax)||(_isIEnumeratorWork == false && _volumeAlarm == VolumeMin))
        {
            StartCoroutine(ChangeVolue());
            _isIEnumeratorWork = true;
        } 
    }

    private IEnumerator ChangeVolue()
    {
        while (_audio.volume != _volumeAlarm)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _volumeAlarm, _step);
            yield return _timePause;
        }

        Debug.Log("_isIEnumeratorWork" + _isIEnumeratorWork);
        _isIEnumeratorWork = false;
    }
}


