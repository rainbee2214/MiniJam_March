using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rb2d;

    [HideInInspector]
    public Animator anim;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb2d.gravityScale = 0;
    }

    public void Move(Vector2 input)
    {
        input.y = 0;
        rb2d.MovePosition(rb2d.position + input.normalized * speed * Time.deltaTime);
        anim.SetBool("Idle", false);
        anim.SetFloat("X", input.x);
        //anim.SetFloat("Y", input.y);
    }

}
