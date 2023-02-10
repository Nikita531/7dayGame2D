using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatformUpDown : MonoBehaviour
{
    float dirY;
   public float speed = 3f;

    bool moveingRight = true;
    // ���������� ��� ���� ����� ���������� �������� ��������.
    public float Up = 0f;
    public float Down = 0f;

    void Update()
    { // �� ����
        if(transform.position.y > Up)
        {
            moveingRight = false;
        }
        else if (transform.position.y < Down)
        {
            moveingRight = true;
        }

        if (moveingRight) // ��������� ������ 2 ��� 3 � ��� �������� ������� x,y,z.
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime );
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime );
        } // � �� ����, ������ ������ ��� ����� ��������� ���������, �� ��� ������! � ���� � ������� �� ����� ��������� � �����������.
    }
}
