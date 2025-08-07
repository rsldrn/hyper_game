// ShootingRunner.cs
using UnityEngine;
using System.Collections;

public class ShootingRunner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private bool isShooting;

    public void StartShooting()
    {
        if (!isShooting)
            StartCoroutine(ShootForSeconds(1f));// 3f yerine 1f ile degistirildi
    }

    private IEnumerator ShootForSeconds(float duration)
    {
        isShooting = true;
        float timer = 0f;

        while (timer < duration)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            yield return new WaitForSeconds(0.3f);
            timer += 0.3f;
        }

        isShooting = false; 
    }
}