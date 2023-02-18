using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageGun : MonoBehaviour
{
    [SerializeField] private List<GarbageBullet> garbagePrefabs;
    [SerializeField] private float power;

    private int lastRN;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GarbageShot();
        }
    }

    private void GarbageShot()
    {
        Vector3 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 speed = (pos - transform.position) * power;
        
        int number;
        do
        {
            number = Random.Range(0, garbagePrefabs.Count);
        } while (number == lastRN);
        lastRN = number;

        Rigidbody2D garbageBullet = Instantiate(garbagePrefabs[number], transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        garbageBullet.AddForce(speed, ForceMode2D.Impulse);
    }
}
