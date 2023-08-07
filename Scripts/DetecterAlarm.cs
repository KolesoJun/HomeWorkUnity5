using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecterAlarm : MonoBehaviour
{
    private AlarmSystem _alarm;
    private bool _isThief;

    private void Start()
    {
        _alarm = GetComponent<AlarmSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ThiefController>(out ThiefController thief))
        {
            _isThief = true;
            _alarm.SetupModeAlarm(_isThief);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ThiefController>(out ThiefController thief))
        {
            _isThief = false;
            _alarm.SetupModeAlarm(_isThief);
        }
    }
}
