using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public float fuerzaSalto;
    private Rigidbody2D Object;
    public Transform pie;
    public LayerMask Suelo;
    public float radioPie;
    public bool verificar;
    private Rigidbody2D rb;
    private Animator animator;
    public bool Jump = false;
    public bool Jumping = true;
    void Start()
    {
        fuerzaSalto = 9f;
        Object = GetComponent<Rigidbody2D> ();
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = new Vector2(0, fuerzaSalto);
    }
        //  if (Input.GetKey("w")) {
        //     animator.SetBool("Jump", true);
        // }
    private void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Piso 1" || col.gameObject.name == "Piso 2" || col.gameObject.name == "Piso 3") {
            Jump = true;
        } else {
            Jump = false;
        }
    }
}
