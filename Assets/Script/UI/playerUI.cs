using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUI : MonoBehaviour
{
    
    private Image image;
    private GameObject player;

    private float Player_Hp;

    private PlayerASkill aSkill;
    private Player_HP hp;

    private void Awake()
    {
        image = GetComponent<Image>();
        player = GameObject.Find("Player");
        aSkill = player.GetComponentInChildren<PlayerASkill>();
        hp = player.GetComponent<Player_HP>();
    }

    private void Start()
    {
       //Player_Hp = hp.Hp;
}
    private void Update()
    {
        image.fillAmount = hp.Hp / 100;

    }
}
