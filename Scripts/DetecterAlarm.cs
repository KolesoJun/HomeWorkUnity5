using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecterAlarm : MonoBehaviour
{
    private List<ThiefController> _thiefs = new List<ThiefController>();
    private AlarmSystem _alarm;

    private void Start()
    {
        _alarm = GetComponent<AlarmSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ThiefController>(out ThiefController thief))
        {
            _thiefs.Add(thief);
            _alarm.SetupModeAlarm(_thiefs.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ThiefController>(out ThiefController thief))
        {
            if (_thiefs.Contains(thief))
                _thiefs.Remove(thief);

            _alarm.SetupModeAlarm(_thiefs.Count);
        }
    }
}
