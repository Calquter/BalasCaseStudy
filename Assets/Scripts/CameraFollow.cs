using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerOBJ;
    private Vector3 _cameraOffset;

    private void Start()
    {
        _cameraOffset = transform.position - _playerOBJ.position;
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, _playerOBJ.transform.position + _cameraOffset, 0.07f);
    }
}
