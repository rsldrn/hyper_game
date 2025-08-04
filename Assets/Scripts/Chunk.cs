using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Vector3 size;
    
    public float GetLength() 
    { 
        return size.z;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue; //Chunk i cevreleyen kafes
        Gizmos.DrawWireCube(transform.position, size);
    }

}
