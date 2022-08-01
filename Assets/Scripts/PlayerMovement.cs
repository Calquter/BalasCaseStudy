using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody _rigidBody;
    private Animator _animator;

    public float moveSpeed;
    [SerializeField] private float _turnSpeed;
    private Vector2 _movementValues;

    private float _targetAngle = 0;
    private float _angle = 0;

    private void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody>();
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _movementValues.x = joystick.Horizontal;
        _movementValues.y = joystick.Vertical;

        if (_movementValues.magnitude > .1f)
        {
            _targetAngle = Mathf.Atan2(_movementValues.x, _movementValues.y) * Mathf.Rad2Deg;
            _animator.SetBool("isRunning", true);
        }
        else
            _animator.SetBool("isRunning", false);



        _angle = Mathf.LerpAngle(transform.eulerAngles.y, _targetAngle, _turnSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, _angle, 0);

        _rigidBody.velocity = (Vector3.forward * _movementValues.y + Vector3.right * _movementValues.x).normalized * moveSpeed;
    }
}
