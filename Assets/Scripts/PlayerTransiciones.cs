using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTransiciones : MonoBehaviour
{
    public float timegame = 5;
    private SpriteRenderer Sprite;
    private Rigidbody2D Object;
    public Animator animator;
    private int StatusAnimation = 0;
    private float hSpeed = 7.0f;
    private Vector3 miraIzquierda = new Vector3(0, 180, 0);
    private Vector3 miraDerecha = new Vector3(0, 0, 0);
    private bool Jump;
    void Start()
    {
        animator = GetComponent<Animator>();
        this.Object = GetComponent<Rigidbody2D> ();
        this.Sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        this.Animation();
        this.Move(Input.GetAxis("Horizontal"));
        this.Flip(Input.GetAxis("Horizontal"));
    }
    void Move(float horizontal)
    {
        // Debug.Log(this.CanJump);
        // controllers
        float x = horizontal * this.timegame;
        // float y; 
        // controllers
        this.Object.velocity = new Vector2(x,this.Object.velocity.y);    
    }
    void Flip(float horizontal)
    {
        if (horizontal < 0) {
            this.Sprite.flipX = true;
        }
        if ( horizontal > 0 ) {
            this.Sprite.flipX = false;
        }

    }
    void TestDeEvento()
    {
        print("Evento gatillado desde una animación");
    }
    void Animation() {
        Debug.Log(GetComponent<Salto>().Jump);
        // animator.SetInteger("Estado", 1);
        // if (Input.GetKeyDown("a"))
        if (GetComponent<Salto>().Jump) {
            if (Input.GetKey("w")) {
                animator.SetBool("Jump", true);
                Object.velocity = new Vector2(0, GetComponent<Salto>().fuerzaSalto);
            } else {
                animator.SetBool("Jump", false);
            }

            if (Input.GetKey("s")) {
                animator.SetBool("Sit", true);
            } else {
                animator.SetBool("Sit", false);
            }
        }
        if (Input.GetAxisRaw("Horizontal") != 0) {
            animator.SetBool("Walk", true);
        //     Debug.Log(animator);
        } else {
            animator.SetBool("Walk", false);
        }
    }
}


