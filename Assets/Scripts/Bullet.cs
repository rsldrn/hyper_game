using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;

    private Coroutine disableCoroutine;

    private void OnEnable()
    {
        disableCoroutine = StartCoroutine(DisableAfterTime(lifetime));
    }

    private void OnDisable()
    {
        if (disableCoroutine != null)
            StopCoroutine(disableCoroutine);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private IEnumerator DisableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        BulletPool.Instance.ReturnBullet(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(1);
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }
}
