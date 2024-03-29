using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace WhiteBall
{
    public class Player : MonoBehaviour, IControllable
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _health;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpPower;

        [SerializeField] private HUD _hud;
        public Joystick _joystick;
        private float directionJostick;
        private float directionKeyboard;
        private Rigidbody2D _rigidbody;

        public static Player Instance { get; set; }

        private void Start()
        {
            _rigidbody= GetComponent<Rigidbody2D>();

            Instance = this;
        }

        private void FixedUpdate()
        {
            directionJostick = _joystick.Horizontal;
            directionKeyboard = Input.GetAxis("Horizontal");
            Move();
        }

        private void Update()
        {
            if (transform.position.y < -20)
            {
                SceneManager.LoadScene(0);
            }

        }

        public void Move()
        {
            Vector2 movement = new Vector2(directionJostick * _speed, _rigidbody.velocity.y);
            Vector2 movement2 = new Vector2(directionKeyboard * _speed, _rigidbody.velocity.y);
            _rigidbody.AddForce(movement);
            _rigidbody.AddForce(movement2);
        }

        public void Jump()
        {
            if (_rigidbody.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower);
            }
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            //_hud.DestroyHeart();
            if (_health <= 0)
                SceneManager.LoadScene(0);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var enemy = collision.gameObject.GetComponent<BaseEnemy>();
            if (enemy == null)
                return;
            foreach (ContactPoint2D point in collision.contacts) 
            {
                if (point.normal.y >= 0.5f)
                    enemy.TakeDamage(_damage);
                else
                    TakeDamage(enemy.Damage);
            }
        }

    }
}