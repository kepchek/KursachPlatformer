using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb; //Переменная, хранящая в себе физику персонажа
    public SpriteRenderer sr; //Переменная, хранящая в себе информацию об спрайте игрока
    
    public static Vector3 checkpoint;
    void Start() //Метод вызывается при загрузке сцены
    {
        rb = GetComponent<Rigidbody2D>(); //Объявление переменной rb, через поиск на объекте нужного компонента
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() //Метод вызывается каждый кадр
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
            sr.flipX = false;
        }
        else if (movevector.x < 0)
        {
            sr.flipX = true;
        }
    }

    public bool onGround;
    public Transform GroundChecker;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    void CheckingGround() //Проверка на нахождение на земле, для избежания бесконечных прыжков
    {
        onGround = Physics2D.OverlapCircle(GroundChecker.position, checkRadius, Ground);
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
