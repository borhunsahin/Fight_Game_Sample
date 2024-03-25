using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;
    PlayerControllerOne playerControllerOne;
    void Start()
    {
        playerControllerOne = GameObject.FindWithTag("PlayerOne").GetComponent<PlayerControllerOne>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerOne"))
        {
            Destroy(gameObject);
            
            if(!playerControllerOne.onBlock)
            {
                playerControllerOne.health -= 10;
                playerControllerOne.animatorPl.SetTrigger("isTakeHit");
            }  
            else
                playerControllerOne.health -= 1;
        }
    }
}
