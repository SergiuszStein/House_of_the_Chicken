using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_AI : MonoBehaviour
{
    private Fox_Sniffing _foxSniffing;
    private Fox_CharacterController _foxCharacterController;
    private Fox_Sight _foxSight;

    private void Awake()
    {
        _foxSniffing = GetComponent<Fox_Sniffing>();
        _foxCharacterController = GetComponent<Fox_CharacterController>();
        _foxSight = GetComponent<Fox_Sight>();
    }

    private void Update()
    {
        _foxCharacterController.Move(_foxSniffing.Get_SmellDirection());
    }

    public void ChickenDetected()
    {
        
    }
}
