using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] public float _smell;

    void Awake()
    {
        _smell = _lifeTime;
    }
    
    void LateUpdate()
    {
        _smell -= Time.deltaTime;

        if (_smell <= 0)
        {
            Destroy(gameObject);
        }
    }
}
