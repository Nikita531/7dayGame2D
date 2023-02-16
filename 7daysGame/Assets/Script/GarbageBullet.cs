using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBullet : MonoBehaviour
{
    [SerializeField] private int bulletDamage = 10;
    private float rotateSpeed = -100;
    private Rigidbody2D _rb;

    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(BulletCouratine());
    }

    private void FixedUpdate()
    {
        float angle = transform.localEulerAngles.z;
        transform.Rotate(0, 0, rotateSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator BulletCouratine()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
            Destroy(this.gameObject);
        }
    }
}
