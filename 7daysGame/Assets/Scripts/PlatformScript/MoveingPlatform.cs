using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour
{
    float dirX;
   public float speed = 3f;

    bool moveingRight = true;
    // переменные дл€ того чтобы ограничить движение платформ.
    public float left = 0f;
    public float right = 0f;

    void Update()
    { // от сюда
        if(transform.position.x > right)
        {
            moveingRight = false;
        }
        else if (transform.position.x < left)
        {
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        } // и до сюда, скрипт делает так чтобы платформа двигалась, но без игрока! ј если с игроком то нужно дополнить в контроллере.
    }
}
