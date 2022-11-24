using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Timeline;

public class Fox_CharacterController : MonoBehaviour
{
    private Fox_AI _foxAI;
    
    private CharacterController _characterController;
    [SerializeField] private GameObject _model;
    [SerializeField] private float _speed;
    private Vector3 _lastMovementDirection;
    
    private void Awake()
    {
        _foxAI = GetComponent<Fox_AI>();
        
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 _movementDirection)
    {
        _characterController.Move(_movementDirection * _speed * Time.deltaTime);

        if (_movementDirection != Vector3.zero)
        {
            _lastMovementDirection = _movementDirection;
        }
    }

    public void Update()
    {
        _model.transform.rotation = Quaternion.Lerp(_model.transform.rotation, Quaternion.LookRotation(_lastMovementDirection), (Time.deltaTime * 10));
    }
}
