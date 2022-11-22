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
    [SerializeField] private float _speed;
    private CharacterController _characterController;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 _movementDirection)
    {
        _characterController.Move(_movementDirection * _speed * Time.deltaTime);
    }
}
