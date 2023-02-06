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



    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        normalSpeed = speed;
        _isPlayerNear = false;

        explosion = Resources.Load("Explosion");



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
            Destroy(gameObject);
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

}