using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhiteBall
{

    public abstract class BaseEnemy : MonoBehaviour, IControllable
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _health;
        [SerializeField] private float _speed;
        [SerializeField] private float _leftBoardPatrol;
        [SerializeField] private float _rightBoardPatrol;

        public float Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public float Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public float LeftBoardPatrol
        {
            get { return _leftBoardPatrol; }
        }

        public float RightBoardPatrol
        {
            get { return _rightBoardPatrol; }
        }

        public Rigidbody2D Rigidbody { get; set; }

        public virtual void MoveEnemy()
        {
            Rigidbody.velocity = new Vector2(Speed, Rigidbody.velocity.y);
        }

        public void Move()
        {
            MoveEnemy();
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}