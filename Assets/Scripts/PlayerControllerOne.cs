using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerOne : Warrior
{
    PlayerControllerTwo playerControllerTwo;
    public Image healthBar;

    private float horizontalPlayerOne;
    public float playerOneX;

    private float distance;
    void Start()
    {
        playerControllerTwo = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<PlayerControllerTwo>();
        Controllers();
    }

    void Update()
    {
        horizontalPlayerOne = Input.GetAxis("Horizontal");

        playerOneX = transform.position.x;
        distance = playerControllerTwo.playerTwoX - playerOneX;

        Movements();
        Actions();
        TransformRotation(distance);
        Dead(health);

        if (playerControllerTwo.playerTwoAttack)
        {
            TakeDamage(health);
            health -= 1;
        }

        healthBar.fillAmount = health/200;
    }
    private void Controllers()
    {
        moveLeft = KeyCode.A;
        moveRight = KeyCode.D;
        jump = KeyCode.W;
        rollRight = KeyCode.C;
        rollLeft = KeyCode.Z;
        attack_1 = KeyCode.Alpha1;
        attack_2 = KeyCode.Alpha2;
        attack_3 = KeyCode.Alpha3;
        attack_s1 = KeyCode.Q;
        attack_s2 = KeyCode.E;
        defend = KeyCode.F;
    }
    private void Movements()
    {
        if (!Input.anyKey)
        {
            Idle();
        }
        if (Input.GetKey(moveRight))
        {
            Move(moveRight, runForce, horizontalPlayerOne, distance);
        }
        if (Input.GetKey(moveLeft))
        {
            Move(moveLeft, runForce, horizontalPlayerOne, distance);
        }
        if (Input.GetKeyDown(jump))
        {
            Jump(jumpForce);
        }
        if (Input.GetKey(moveRight) && Input.GetKeyDown(rollRight))
        {
            //Roll(KeyCode.C, rollForce);
        }
        if (Input.GetKey(moveLeft) && Input.GetKeyDown(rollLeft))
        {
            //Roll(KeyCode.Z, rollForce);
        }
    }
    private void Actions()
    {
        if (Input.GetKeyDown(attack_1))
        {
            Attack(attack_1);
            if (Mathf.Abs(distance) < 3)
            {
                playerOneAttack = true;
            }
        }
        if (Input.GetKeyDown(attack_2))
        {
            Attack(attack_2);
        }
        if (Input.GetKeyDown(attack_3))
        {
            Attack(attack_3);
            if (Mathf.Abs(distance) > 5)
            {
                playerOneAttack = true;
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
}
