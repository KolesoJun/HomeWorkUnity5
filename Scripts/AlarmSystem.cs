using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _step;

    private List<ThiefController> _thiefs = new List<ThiefController>();
    private AudioSource _audio;
    private float _volueMax = 1f;
    private float _volueMin = 0f;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_thiefs.Count > 0)
            _audio.volume = Mathf.MoveTowards(_audio.volume, _volueMax, _step * Time.deltaTime);
        else
            _audio.volume = Mathf.MoveTowards(_audio.volume, _volueMin, _step * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ThiefController>(out ThiefController thief))
        {
            _audio.Play();
            _thiefs.Add(thief);
        }  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ThiefController>(out ThiefController thief))
        {
            if (_thiefs.Contains(thief))
                _thiefs.Remove(thief);
        }
    }
}


