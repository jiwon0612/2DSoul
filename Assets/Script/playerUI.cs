using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUI : MonoBehaviour
{
    
    private Image image;

    private float Player_Hp;

    private void Awake()
    {
        image = GetComponent<Image>();
        
    }

    private void Start()
    {
       Player_Hp = Player_Manager.instans.Hp;
}
    private void Update()
    {
        Player_Hp = Player_Manager.instans.Hp;
        image.fillAmount = Player_Hp / 100;

    }
}
