using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class ThiefController : MonoBehaviour
{
    public const string AxisHorizontal = "Horizontal";

    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis(AxisHorizontal) * Time.deltaTime;
        transform.Translate(horizontal * _speed, 0, 0);
    }
}
