using UnityEngine;

public class ShootingCubeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Runner prefabinin tag’i
        {
            ShootingRunner shooter = other.GetComponent<ShootingRunner>();
            if (shooter != null)
            {
                shooter.StartShooting(); 
            } 
        } 
    }
}