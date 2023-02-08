using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bread : MonoBehaviour
{
    public TMP_Text Breadstext;
    private float breads = 0;
    // скрипт повесить на персонажа
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bread")
        {
            breads++;
            Breadstext.text = breads.ToString();
            Destroy(coll.gameObject);
        }
    }
}



