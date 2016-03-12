using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player1 : MonoBehaviour
{
    PlayerMovement movement;
    SpriteRenderer sr;

    Vector2 input;
    float explosionDelay = 0.2f;
    float lastExplosionTime;

    GameObject explosion;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        explosion = Resources.Load<GameObject>("Prefabs/Explosion1");
    }

    void Update()
    {
        input.Set(Input.GetAxisRaw("Horizontal1"), Input.GetAxisRaw("Vertical1"));
        if (Input.GetButtonDown("Drop") && Time.time > lastExplosionTime)
        {
            DropExplosion();
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(input.x) > 0 || Mathf.Abs(input.y) > 0)
            movement.Move(input);
        //else
        //    movement.anim.SetBool("Idle", true);
    }

    void DropExplosion()
    {
        Debug.Log("Dropping explosion!");
        AudioController.controller.PlaySound(Sound.Explosion1);
        lastExplosionTime = Time.time + explosionDelay;
        GameObject e = Instantiate<GameObject>(explosion);
        e.transform.position = transform.position;
        //e.transform.SetParent(transform);
        e.name = "Explosion";
    }
}
