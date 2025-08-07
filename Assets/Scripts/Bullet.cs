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
        // if (other.TryGetComponent<Enemy>(out var enemy)) // Enemy.cs varsa  //altarnetif yol
        // {
        //     Destroy(enemy.gameObject);   // Enemy'yi yok et
        //     Destroy(gameObject);         // Bullet'i yok et
        // }

        if (other.GetComponent<Enemy>())
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    } 
}