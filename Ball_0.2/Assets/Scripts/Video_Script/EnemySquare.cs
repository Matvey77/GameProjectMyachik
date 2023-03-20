using WhiteBall;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhiteBall
{
    public class EnemySquare : BaseEnemy
    {
        private IControllable _controlableObj;
        private float _directionMove = 1;

        private void Start()
        {
            _controlableObj = GetComponent<IControllable>();
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (transform.position.x > RightBoardPatrol || transform.position.x < LeftBoardPatrol)
            {
                _directionMove = -_directionMove;
            }
        }

        private void FixedUpdate()
        {
            _controlableObj.Move();
        }

        public override void MoveEnemy()
        {
            Rigidbody.velocity = new Vector2(Speed * _directionMove, Rigidbody.velocity.y);
        }
    }
}