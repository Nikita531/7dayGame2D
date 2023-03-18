using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarbageGun : MonoBehaviour
{
    [SerializeField] private List<GarbageBullet> garbagePrefabs;
    [SerializeField] private float power;
    [SerializeField] private Image reloadBarImage;

    private Coroutine reloadCoroutine;
    private Coroutine stopReloadCoroutine;
    private float reloadBarValue;

    private Camera mainCamera;
    public Animator anim;

    private void Start()
    {
        reloadBarValue = 1;
        mainCamera = Camera.main;
        reloadCoroutine = StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (reloadBarValue < 1f)
            {
                reloadBarValue += 0.1f; 
                reloadBarImage.fillAmount = reloadBarValue;
            }
        }
    }

    private IEnumerator StopReloadCoroutine()
    {
        StopCoroutine(reloadCoroutine);
        yield return new WaitForSeconds(1.5f);
        stopReloadCoroutine = null;
        reloadCoroutine = StartCoroutine(ReloadCoroutine());
    }

    private void ChangeReloadBarValue()
    {
        if (reloadBarValue > 0)
        {
            reloadBarValue -= 0.1f;
            if (stopReloadCoroutine == null)
            {
                stopReloadCoroutine = StartCoroutine(StopReloadCoroutine());
            }
            reloadBarImage.fillAmount = reloadBarValue;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && reloadBarValue > 0.1f)
        {
            anim.SetTrigger("PlayerAttack");
            //float enter;
            Vector3 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //Ray ray = mainCamera.ScreenPointToRay(pos);
            Vector2 speed = (pos - transform.position) * power;
            int number = Random.Range(0, garbagePrefabs.Count);
            Rigidbody2D garbageBullet = Instantiate(garbagePrefabs[number], transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            garbageBullet.AddForce(speed, ForceMode2D.Impulse);
            ChangeReloadBarValue();
        }
    }
    public void OnAttack()
    {
            
    }
}
