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

    [Header("AI")]
    [SerializeField] private bool _prioritizeFeathersFurtherAway;

    [Header("Variables")]
    private Collider[] _feathers;
    [SerializeField] private float _speed;
    [SerializeField] private float _sniffRadius;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _feathers = Physics.OverlapSphere(transform.position, _sniffRadius, LayerMask.NameToLayer("Feathers"));

        List<Vector3> _featherDirections = new List<Vector3>();

        if (_prioritizeFeathersFurtherAway)
        {
            for (int i = 0; i < _feathers.Length; i++)
            {
                _featherDirections.Add(_feathers[i].gameObject.transform.position - transform.position);
            }
        }
        else
        {
            for (int i = 0; i < _feathers.Length; i++)
            {
                _featherDirections.Add(Vector3.Normalize(_feathers[i].gameObject.transform.position - transform.position));
            }
        }
    }
}
