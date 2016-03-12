using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player2 : MonoBehaviour
{
    PlayerMovement movement;
    SpriteRenderer sr;

    Vector2 input;
    public Slider slider;

    public int health = 10;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        slider.maxValue = health;
    }

    void Update()
    {
        slider.value = health;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("HIT");
        Explosion e = other.gameObject.GetComponent<Explosion>();
        if (e != null)
        {
            e.Explode();
            //e.anim.SetTrigger("Explode");
            AudioController.controller.PlaySound(Sound.Explosion2);
            health--;
            if (health <= 0) GameController.controller.ChangeState(State.GameOver);
        }
    }
}
