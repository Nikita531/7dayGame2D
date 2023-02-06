using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D physic;

    public Transform player;

    public float speed;
    public float NSpeed;
    public float agroDistance;

    public float LocalScaleX;
    public float LocalScaleY;


    public float TimeDelay = 2f;

    void Start()
    {
        //StartCoroutine(AnimAtackSpeedEnemy());
        physic = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);


        if (distToPlayer < agroDistance) 
        {
            Invoke("StartHunting",TimeDelay);
            

        }

        else
        {
            StopHunting();
        }
    }

    public void StartHunting()
    {

        if (player.position.x < transform.position.x)//идет на лево
        {

            physic.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-LocalScaleX, LocalScaleY);
        }

        else if (player.position.x > transform.position.x)//идет на право 
        {

            physic.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(LocalScaleX, LocalScaleY);
        }

    }
    public void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
        
    }
    public IEnumerator AnimAtackSpeedEnemy()
    {
        speed = 0;
        yield return new WaitForSeconds(2);
        speed = NSpeed;
    }

}
