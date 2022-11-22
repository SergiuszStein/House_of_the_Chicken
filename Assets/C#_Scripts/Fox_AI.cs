using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_AI : MonoBehaviour
{
    private Fox_Sniffing _foxSniffing;
    private Fox_CharacterController _foxCharacterController;

    private void Awake()
    {
        _foxSniffing = GetComponent<Fox_Sniffing>();
        _foxCharacterController = GetComponent<Fox_CharacterController>();
    }

    private void Update()
    {
        _foxCharacterController.Move(_foxSniffing.Get_SmellDirection());
    }
}
