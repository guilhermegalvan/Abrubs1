﻿using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;
    public float health;

    private void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if (moveInput != Vector2.zero){
            anim.SetBool("isRunning", true);
        }else{
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate(){
       rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damageAmount){
        health -= damageAmount;
        if (health <= 0){
            Destroy(gameObject);
        }
    }
}
