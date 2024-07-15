using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb; 
    public SpriteRenderer sr; 
    public Animator anim;
    
    public static Vector3 checkpoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
        Jump();
        Flip();
        CheckingGround();
    }

    public float speed = 2f;
    public Vector2 movevector;
    public float jumpforce = 7f;

    void Walk() 
    {
        movevector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movevector.x * speed, rb.velocity.y);
        anim.SetFloat("moveX", Mathf.Abs(movevector.x));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) & onGround)
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpforce);
        }
    }

    void Flip() //Разворот спрайта по направлению движения
    {
        if (movevector.x > 0)
        {
            //sr.flipX = false;
            transform.localScale = new Vector3(-2, 2, 1);
        }
        else if (movevector.x < 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
    }

    public bool onGround;
    public Transform GroundChecker;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    void CheckingGround() //Проверка на нахождение на земле, для избежания бесконечных прыжков
    {
        onGround = Physics2D.OverlapCircle(GroundChecker.position, checkRadius, Ground);
        anim.SetBool("OnGround", onGround);
    }
    void OnCollisionEnter2D(Collision2D other) //При касании смертельной ловушки идёт вызов метода, перезагружающего уровень
    {
        if(other.gameObject.tag == "Death")
        {
            Death();
        }
    }
    void Death()
    {
        SceneManager.LoadScene(0);
    }
}
