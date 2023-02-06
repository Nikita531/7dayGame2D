using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowClip : MonoBehaviour
{
    public Gun Ammo;
    public Player HP;
    private void OnTriggerEnter2D(Collider2D colision)
    {

        if (colision.gameObject.tag == "Ammo")
        {
            Ammo.currentAmmo += 15;
            Destroy(colision.gameObject);
        }

        if (colision.gameObject.tag == "HP")
        {
            HP.Healt += 15;
            Destroy(colision.gameObject);
        }



    }
}
