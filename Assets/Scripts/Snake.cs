using System;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private Tail _tailPrefab;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _directionPoint;
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _rotateSpeed = 90f;

    private Vector3 _targetDirection = Vector3.zero;
    private Tail _tail;

    public void Init(int detailCount)
    {
        _tail = Instantiate(_tailPrefab, transform.position, Quaternion.identity);
        _tail.Init(_head, _speed, detailCount);
    }

    public void SetDetailCount(int detailCount)
    {
        _tail.SetDetailCount(detailCount);
    }

    void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_targetDirection);

        _head.rotation = Quaternion.RotateTowards(_head.rotation, targetRotation, Time.deltaTime * _rotateSpeed);
    }

    private void Move()
    {
        transform.position += _head.forward * Time.deltaTime * _speed;
    }

    public void SetRotation(Vector3 pointToLook)
    {
        _directionPoint.LookAt(pointToLook);
        _head.LookAt(pointToLook);
    }

    public void LerpRotation(Vector3 cursorPosition)
    {
        _targetDirection = cursorPosition - _head.position;
    }

    public void Destroy()
    {
        _tail.Destroy();
        Destroy(gameObject);
    }

    public void GetMoveInfo(out Vector3 position)
    {
        position = transform.position;
    }
}
