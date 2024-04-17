using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] hP_Bar = new Sprite[7];
    private Image image;

    private int Player_Hp;

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
        image.sprite = hP_Bar[Player_Hp];

    }
}
