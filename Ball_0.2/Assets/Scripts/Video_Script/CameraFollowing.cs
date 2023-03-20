using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offset;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _offset.z = -10f;
        var nextPosition = Vector3.Lerp(transform.position, _target.position + _offset, _speed * Time.fixedDeltaTime);
        transform.position = nextPosition;
    }
}
