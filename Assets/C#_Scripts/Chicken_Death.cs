using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Chicken_Death : MonoBehaviour
{
    [SerializeField] private GameObject _bloodSplatter;
    
    public void Die()
    {
        Instantiate(_bloodSplatter, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }
}
