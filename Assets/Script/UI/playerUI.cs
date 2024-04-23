using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUI : MonoBehaviour
{
    
    private Image image;

    private float Player_Hp;

    [SerializeField]
    private Player_HP hp;

    private void Awake()
    {
        image = GetComponent<Image>();
        
    }

    private void Start()
    {
       Player_Hp = hp.Hp;
}
    private void Update()
    {
        Player_Hp = hp.Hp;
        image.fillAmount = Player_Hp / 100;

    }
}
