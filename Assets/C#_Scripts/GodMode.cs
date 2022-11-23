using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _featherPrefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            
            RaycastHit _raycastHit;

            Physics.Raycast(_ray, out _raycastHit, 100f);

            if (_raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Instantiate(_featherPrefab, _raycastHit.point, Quaternion.identity);
            }
        }
    }
}
