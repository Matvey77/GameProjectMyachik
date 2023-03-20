using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontalMove : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rightBoardPatrol;
    [SerializeField] private float _leftBoardPatrol;
    private float _directionMove = 1;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       if (transform.position.x > _rightBoardPatrol || transform.position.x < _leftBoardPatrol)
       {
            _directionMove = -_directionMove;
       }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        _rb.velocity = new Vector2(_speed * _directionMove, _rb.velocity.y);
    }
}
