using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Image HealtBar;
    public float maxHealt;
    public float Healt;
    public Player player;

    private UnityEngine.Object explosion;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        HealtBar = GetComponent<Image>();

        Healt = maxHealt;

        explosion = Resources.Load("Explosion");

    }


    void Update()
    {
        HealtBar.fillAmount = Healt / maxHealt;

        if (Healt <= 0)
        {
            //TODO Create SceneManager
            SceneManager.LoadScene(0);
        }
    }
    public void SetHealth(int bonusHealt)
    {
        Healt += bonusHealt;

        if (Healt > maxHealt)
        {
            Healt = maxHealt;
        }
    }
    public void PlayerEfect()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}
