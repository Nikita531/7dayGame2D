using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public float speed;
    public GameObject deathEffect;
    public int damage;
    private float StopTime;
    public float startStopTime;
    public float normalSpeed;
    private Player player;
    private Animator anim;
    private bool _isPlayerNear;

    private UnityEngine.Object explosion;
    private UnityEngine.Object EnemyRef;
    private SpriteRenderer SpriteRend;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        normalSpeed = speed;
        _isPlayerNear = false;

        explosion = Resources.Load("Explosion");
        EnemyRef = Resources.Load("EnemyNormal");



    }

    private void Update()
    {
        if (StopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            StopTime = Time.deltaTime;
        }
        if (health <= 0)
        {
            GameObject explosionRef = (GameObject)Instantiate(explosion);
            explosionRef.transform.position = new Vector2(transform.position.x, transform.position.y);
            //Destroy(gameObject);
            gameObject.SetActive(false);

            Invoke("Respawn", 5f);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        StopTime = startStopTime;
        health -= damage;
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("EnemyAttack");
                
                timeBtwAttack = startTimeBtwAttack;
                
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
            
            _isPlayerNear = true;
            
        }

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNear = false;
        }
    }





    public void OnEnemyAttack()
    {
        if (_isPlayerNear)
        {
            player.Healt -= damage;
            player.PlayerEfect();
            

        }

    }
    void Respawn()
    {
        Debug.Log("work");
        GameObject enemyCopy = (GameObject)Instantiate(EnemyRef);
        enemyCopy.transform.position = transform.position;
        health += 100; gameObject.SetActive(true);


        Destroy(gameObject);
    }

}