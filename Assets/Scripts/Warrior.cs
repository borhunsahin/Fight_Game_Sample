using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D playerRb;
    [SerializeField] public Animator animatorPl;

    [SerializeField] protected float runForce;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float rollForce;

    public float health;

    public bool onBlock = false;

    public bool playerOneAttack = false;
    public bool playerTwoAttack = false;

    protected KeyCode moveLeft;
    protected KeyCode moveRight;
    protected KeyCode jump;
    protected KeyCode rollRight;
    protected KeyCode rollLeft;
    protected KeyCode attack_1;
    protected KeyCode attack_2;
    protected KeyCode attack_3;
    protected KeyCode attack_s1;
    protected KeyCode attack_s2;
    protected KeyCode defend;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animatorPl = GetComponent<Animator>();
    }
    protected void Idle()
    {
        animatorPl.SetBool("isRunForward", false);
        animatorPl.SetBool("isRunBackward", false);
        animatorPl.SetBool("isIdle", true);

        onBlock = false;
        playerOneAttack = false;
        playerTwoAttack = false;
    }
    protected void Move(KeyCode key, float runForce,float horizontal,float distance)
    {
        animatorPl.SetBool("isIdle", false);

        if (key == moveRight)
        {
            playerRb.AddForce(Vector2.right * runForce * horizontal * Time.deltaTime, ForceMode2D.Impulse);

            if (distance>0)
            {
                animatorPl.SetBool("isRunForward", true);
                animatorPl.SetBool("isRunBackward", false);
            }
            else
            {
                animatorPl.SetBool("isRunBackward", true);
                animatorPl.SetBool("isRunForward", false);
            }
        }
        if (key == moveLeft)
        {
            playerRb.AddForce(Vector2.right * runForce * horizontal * Time.deltaTime, ForceMode2D.Impulse);

            if (distance > 0)
            {
                animatorPl.SetBool("isRunBackward", true);
                animatorPl.SetBool("isRunForward", false);
            }
            else
            {
                animatorPl.SetBool("isRunForward", true);
                animatorPl.SetBool("isRunBackward", false);
            }
        }
    }
    protected void Jump(float jumpForce)
    {
        playerRb.AddForce(Vector2.up * jumpForce);
        animatorPl.SetTrigger("isJump");
    }
    /*
    protected void Roll(KeyCode key, float rollForce)
    {
        if (key == KeyCode.C || key == KeyCode.KeypadPeriod)
        {
            playerRb.AddForce(Vector2.right * rollForce * Time.deltaTime, ForceMode2D.Impulse);
            animatorPl.SetTrigger("isRoll");
        }
        if (key == KeyCode.Z || key == KeyCode.Keypad0)
        {
            playerRb.AddForce(Vector2.left * rollForce * Time.deltaTime, ForceMode2D.Impulse);
            animatorPl.SetTrigger("isRoll_Back");
        }
    }
    */
    protected void Attack(KeyCode key)
    {
        if (key == attack_1)
        {
            animatorPl.SetTrigger("isAttack_1");
        }
        if (key == attack_2)
        {
            animatorPl.SetTrigger("isAttack_2");
        }
        if (key == attack_3)
        {
            animatorPl.SetTrigger("isAttack_3");
        }
        if (key == KeyCode.Q || key == KeyCode.KeypadEnter)
        {
            //animatorPl.SetTrigger("isAttack_S1");
        }
        if (key == KeyCode.E || key == KeyCode.LeftShift)
        {
            //animatorPl.SetTrigger("isAttack_S2");
        }
    }
    protected void Defend()
    {
        animatorPl.SetTrigger("isDefend");
        onBlock = true;
    }
    protected void TransformRotation(float distance)
    {
        Vector2 plus = new Vector2(transform.position.x, 0);
        Vector2 minus = new Vector2(transform.position.x, 180);

        if (distance < 0)
        {
            transform.rotation = Quaternion.Euler(minus);
        }
        else
        {
            transform.rotation = Quaternion.Euler(plus);
        }
    }
    protected void TakeDamage(float health)
    {
        animatorPl.SetTrigger("isTakeHit");
        //health -= 10;
    }
    protected void Dead(float health)
    {
        if(health<1)
            animatorPl.SetTrigger("isDead");
    }
}