using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageGun : MonoBehaviour
{
    [SerializeField] private List<GarbageBullet> garbagePrefabs;
    [SerializeField] private float power;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float enter;
            Vector3 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //Ray ray = mainCamera.ScreenPointToRay(pos);
            Vector2 speed = (pos - transform.position) * power;
            int number = Random.Range(0, garbagePrefabs.Count);
            Rigidbody2D garbageBullet = Instantiate(garbagePrefabs[number], transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            garbageBullet.AddForce(speed, ForceMode2D.Impulse);

        }
    }
}
