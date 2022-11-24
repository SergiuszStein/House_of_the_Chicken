using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_Sniffing : MonoBehaviour
{
    private Fox_AI _foxAI;
    
    [SerializeField] private bool _prioritizeFeathersFurtherAway;
    [SerializeField] private float _sniffRadius;
    
    private List<Feather> _feathers;
    private Collider[] _featherColliders;
    private Vector3 _smellDirection;

    public Vector3 Get_SmellDirection()
    {
        return _smellDirection;
    }

    private void Awake()
    {
        _foxAI = GetComponent<Fox_AI>();
        
        _feathers = new List<Feather>();
    }

    private void Update()
    {
        _feathers = new List<Feather>();
        
        _featherColliders = Physics.OverlapSphere(transform.position, _sniffRadius);

        for (int i = 0; i < _featherColliders.Length; i++)
        {
            if (_featherColliders[i].gameObject.layer == LayerMask.NameToLayer("Feathers"))
            {
                _feathers.Add(_featherColliders[i].gameObject.GetComponent<Feather>());
            }
        }

        for (int i = 0; i < _feathers.Count; i++)
        {
            Debug.DrawLine(
                transform.position + new Vector3(0, 0.1f, 0),
                _feathers[i].gameObject.transform.position - transform.position + new Vector3(0, 0.1f, 0),
                Color.green, 0.1f
            );
        }

        List<Vector3> _featherDirections = new List<Vector3>();

        for (int i = 0; i < _feathers.Count; i++)
        {
            if (_prioritizeFeathersFurtherAway)
            {
                _featherDirections.Add((_feathers[i].gameObject.transform.position - transform.position) * _feathers[i]._smell);
            }
            else
            {
                _featherDirections.Add(Vector3.Normalize(_feathers[i].gameObject.transform.position - transform.position) * _feathers[i]._smell);
            }
        }

        _smellDirection = Vector3.zero;

        for (int i = 0; i < _featherDirections.Count; i++)
        {
            _smellDirection += _featherDirections[i];
        }

        _smellDirection = Vector3.Normalize(_smellDirection);

        _smellDirection.y = 0;
    }
}
