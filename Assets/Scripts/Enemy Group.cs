using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header("Elements")] 
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemyParent;
    
    [Header("Setting")] 
    [SerializeField] private int amount;
    [SerializeField] private float radius;
    [SerializeField] private float angel;
    void Start()
    {
        EnemyGenerate();
    }

    private void EnemyGenerate()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 enemyLocalPosition = PlayerRunnerLocalPosition(i);
            enemyLocalPosition += transform.position;
            Instantiate(enemyPrefab, enemyLocalPosition, Quaternion.identity, enemyParent);
        }
    }
    
    private Vector3 PlayerRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angel);
        float y = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angel);
        return new Vector3(x, 0, y);
    }
    
}
