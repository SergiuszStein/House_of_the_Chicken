using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_Sight : MonoBehaviour
{
    private Fox_AI _foxAI;

    private void Awake()
    {
        _foxAI = GetComponent<Fox_AI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Chicken"))
        {
            _foxAI.ChickenDetected();
        }
    }
}
