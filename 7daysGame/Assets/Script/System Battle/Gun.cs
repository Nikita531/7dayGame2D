using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public float GunScaleX;
    public float GunScaleY;
    public float GunScaleZ;


    public int currentAmmo = 10;
    public int allAmmo;


    [SerializeField]
    private Text ammoCount;
    void Update()
    {
        Vector3 diffence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diffence.y, diffence.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0) && currentAmmo > 0)
            {
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                timeBtwShots = startTimeBtwShots;
                currentAmmo -= 1;
            }

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        //Vector3 LocalScale = Vector3.one;
        //if(rotZ > 90|| rotZ < -90)
        //{
        //LocalScale = new Vector3(GunScaleX, -GunScaleY, GunScaleZ) ;
        //}
        //else
        //{
        //LocalScale = new Vector3(GunScaleX, GunScaleY, GunScaleZ) ;
        //}
        //transform.localScale = LocalScale;


        // Отображение пуль или стрел.
        ammoCount.text = currentAmmo + " / " + allAmmo;
    }

}
