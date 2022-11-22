using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Timeline;

public class Fox_AI : MonoBehaviour
{
    [Header("GameObject")]
    private CharacterController _characterController;
    
    [Header("Variables")]
    [SerializeField] private float _speed;
    [SerializeField] private float _sniffRadius;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Physics.OverlapSphere(transform.position, _sniffRadius, LayerMask.NameToLayer("Feathers"));
    }
}
