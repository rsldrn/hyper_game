using UnityEngine;
using System.Collections;

public class ShootingRunner : MonoBehaviour
{
    public Transform bulletSpawnPoint;

    private bool isShooting;

    public void StartShooting()
    {
        if (!isShooting)
            StartCoroutine(ShootForSeconds(1f));
    }

    private IEnumerator ShootForSeconds(float duration)
    {
        isShooting = true;
        float timer = 0f;

        while (timer < duration)
        {
            GameObject bullet = BulletPool.Instance.GetBullet();
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = bulletSpawnPoint.rotation;

            yield return new WaitForSeconds(0.3f);
            timer += 0.3f;
        }

        isShooting = false;
    }
}
