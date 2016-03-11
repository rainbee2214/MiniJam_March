﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player2 : MonoBehaviour
{
    PlayerMovement movement;
    SpriteRenderer sr;

    Vector2 input;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        input.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(input.x) > 0 || Mathf.Abs(input.y) > 0)
        {
            movement.Move(input);
        }
        else
            movement.anim.SetBool("Idle", true);
    }
}
