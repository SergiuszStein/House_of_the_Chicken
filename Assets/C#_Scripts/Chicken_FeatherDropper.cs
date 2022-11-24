using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chicken_FeatherDropper : MonoBehaviour
{
    private float _dropFrequency;
    [SerializeField] private float _dropFrequencySneak;
    [SerializeField] private float _dropFrequencyRun;
    private float _dropTimer;
    [SerializeField] private GameObject _feather;

    private Chicken_CharacterController _chickenCharacterController;

    private void Awake()
    {
        _chickenCharacterController = GetComponent<Chicken_CharacterController>();
    }

    private void Update()
    {
        if (_chickenCharacterController.Get_isSneaking())
        {
            _dropFrequency = _dropFrequencySneak;
        }
        else
        {
            _dropFrequency = _dropFrequencyRun;
        }

        if (_dropTimer <= 0)
        {
            _dropTimer = _dropFrequency;

            Instantiate(_feather, transform.position, Quaternion.identity);
        }
        else
        {
            _dropTimer -= Time.deltaTime;
        }
    }
}
