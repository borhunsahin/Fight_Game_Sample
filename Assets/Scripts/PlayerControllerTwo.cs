using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerTwo : Warrior
{
    PlayerControllerOne playerControllerOne;
    public Image healthBar;

    private float horizontalPlayerTwo;
    public float playerTwoX;


    private float distance;
    [SerializeField] private GameObject arrow;
    void Start()
    {
        playerControllerOne = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerControllerOne>();
        Controllers();
    }
    void Update()
    {
        horizontalPlayerTwo = Input.GetAxis("Vertical");

        playerTwoX = transform.position.x;
        distance = playerControllerOne.playerOneX - playerTwoX;

        Movements();
        Actions();
        TransformRotation(distance);
        Dead(health);

        if(playerControllerOne.playerOneAttack)
        {
            TakeDamage(health);
            health -= 1;
        }

        healthBar.fillAmount = health / 200;

    }
    private void Controllers()
    {
        moveLeft = KeyCode.Keypad1;
        moveRight = KeyCode.Keypad3;
        jump = KeyCode.Keypad5;
        rollRight = KeyCode.Keypad0;
        rollLeft = KeyCode.KeypadPeriod;
        attack_1 = KeyCode.Keypad7;
        attack_2 = KeyCode.Keypad8;
        attack_3 = KeyCode.Keypad9;
        attack_s1 = KeyCode.KeypadPlus;
        attack_s2 = KeyCode.KeypadEnter;
        defend = KeyCode.Keypad6;
    }
    private void Movements()
    {
        if (!Input.anyKey)
        {
            Idle();
        }
        if (Input.GetKey(moveLeft))
        {
            Move(moveLeft, runForce, horizontalPlayerTwo, distance);
        }
        if (Input.GetKey(moveRight))
        {
            Move(moveRight, runForce, horizontalPlayerTwo, distance);
        }
        if (Input.GetKeyDown(jump))
        {
            Jump(jumpForce);
        }
        if (Input.GetKey(moveLeft) && Input.GetKeyDown(rollRight))
        {
            //Roll(rollRight, rollForce);
        }
        if (Input.GetKey(moveRight) && Input.GetKeyDown(rollLeft))
        {
            //Roll(rollLeft, rollForce);
        }
    }
    private void Actions()
    {
        if (Input.GetKeyDown(attack_1))
        {
            Attack(attack_1);
            if (Mathf.Abs(distance) < 3)
            {
                playerTwoAttack = true;
            } 
        }
        if (Input.GetKeyDown(attack_2))
        {
            ShootArrow(arrow);
            animatorPl.SetTrigger("isAttack_2");
        }
        if (Input.GetKeyDown(attack_3))
        {
            Attack(attack_3);

            if (Mathf.Abs(distance) > 5)
            {
                playerTwoAttack = true;
            }
        }
        if (Input.GetKeyDown(defend))
        {
            Defend();
        }
        /*Special Actions*/
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack(KeyCode.Q);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack(KeyCode.E);
        }
    }
    private void ShootArrow(GameObject Arrow)
    {
        Instantiate(arrow,new Vector2(transform.position.x,transform.position.y-2),transform.rotation);
    }
}