using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUICanvers : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {
        gameObject.SetActive(true);
        
    }
}
