using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;
    

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        // if (other.TryGetComponent<Enemy>(out var enemy))  //altarnetif yol
        // {
        //     Destroy(enemy.gameObject);  
        //     Destroy(gameObject);         
        // }

        // if (other.GetComponent<Enemy>())    // Enemy.cs varsa
        // {
        //     Destroy(other.gameObject);      // Enemy'yi yok et
        //     Destroy(gameObject);            // Bullet'i yok et
        // }
        
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(1);  // 1 hasar ver
            Destroy(gameObject);  // Mermiyi yok et
        }
    } 
}