using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_CharacterController : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private GameObject _model;
    private float _speed;
    [SerializeField] private float _speedSneak;
    [SerializeField] private float _speedRun;
    [SerializeField] private GameObject _camera;
    private bool _isSneaking = true;

    private Vector3 _lastMovementDirection;
    private Vector3 _movementDirection;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public bool Get_isSneaking()
    {
        return _isSneaking;
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Sneak"))
        {
            if (_isSneaking)
            {
                _isSneaking = false;
            }
            else
            {
                _isSneaking = true;
            }
        }
        
        if (_isSneaking)
        {
            _speed = _speedSneak;
        }
        else
        {
            _speed = _speedRun;
        }

        _movementDirection = Vector3.Normalize((_camera.transform.forward * Input.GetAxisRaw("Vertical")) + (_camera.transform.right * Input.GetAxisRaw("Horizontal")));
            
        _movementDirection.y = 0;

        if (_movementDirection != Vector3.zero)
        {
            _lastMovementDirection = _movementDirection;
            
            _characterController.Move(_movementDirection * _speed * Time.deltaTime);
        }

        _model.transform.rotation = Quaternion.Lerp(_model.transform.rotation, Quaternion.LookRotation(_lastMovementDirection), (Time.deltaTime * 10));
    }
}
