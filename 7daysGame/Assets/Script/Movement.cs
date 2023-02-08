using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float StaminaTimeReturn;
    // Переменные для передвижения
    public float Speed;
    public float MaxSpeed;
    public float LowSpeed;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    //Эти переменные проверяют есть ли земля под ногами, для прыжка.
    public float jumpForce;
    private bool isGrounded = true;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float maxStamina;
    public float Stamina;
    public RunBar RB;
    
    
    //Image RunBar;
    //private Animator anim;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //RunBar = GetComponent<Image>();
        Stamina = maxStamina;
    }


    //void //FixedUpdate()
    //{

    //moveInput = Input.GetAxis("Horizontal");
    //rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
    //if (facingRight == false && moveInput > 0)
    //{
    //Flip();
//}
//else if (facingRight == true && moveInput < 0)
//{
//Flip();
//}
        //if(moveInput == 0)
        //{
        //anim.SetBool("isRuning", false);
        //}
        //else
        //{
        //anim.SetBool("isRuning", true);
        //}
    //}
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        {
            if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {

                rb.velocity = Vector2.up * jumpForce;
            }
            //if(isGrounded== false)
            //{
            //anim.SetBool("isjumping", false);
            //}
            //else
            //{
            //anim.SetBool("isjumping", true);
            //}
        }
        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        {
            Speed = MaxSpeed;
            Stamina -= StaminaTimeReturn * Time.deltaTime;
        }
        else
        {
            Speed = LowSpeed;
            Stamina += StaminaTimeReturn * Time.deltaTime * 2;
        }

        Staminas();
        RB.RunBarr.fillAmount = Stamina / maxStamina;
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            this.transform.parent = collision.transform;
        }
    }
    // нужно добавить платформам в юнити tag platform and leyer Ground.
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            this.transform.parent = null;
        }
    }
    // Эта часть кода отвечает за респавн после столкновения с препятствием, нужно указать в проэкте на ловушке is trigger в коллайдере,
    // и в file- bild setings перетащить сцену, справа будет написан ее номер. Добавить в плейр контроллер using UnityEngine.SceneManagement;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            SceneManager.LoadScene(0);
            
        }
        if (other.tag == "Finish")
            {
                SceneManager.LoadScene(3);
            }
    }
    private void Staminas()
    {
        if (Stamina > maxStamina) Stamina = maxStamina;
    }

    
    
        
    
}
