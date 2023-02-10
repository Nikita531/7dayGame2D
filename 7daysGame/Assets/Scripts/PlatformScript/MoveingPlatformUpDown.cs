using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatformUpDown : MonoBehaviour
{
    float dirY;
   public float speed = 3f;

    bool moveingRight = true;
    // переменные дл€ того чтобы ограничить движение платформ.
    public float Up = 0f;
    public float Down = 0f;

    void Update()
    { // от сюда
        if(transform.position.y > Up)
        {
            moveingRight = false;
        }
        else if (transform.position.y < Down)
        {
            moveingRight = true;
        }

        if (moveingRight) // компонент вектор 2 или 3 в нем прописан пор€док x,y,z.
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime );
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime );
        } // и до сюда, скрипт делает так чтобы платформа двигалась, но без игрока! ј если с игроком то нужно дополнить в контроллере.
    }
}
