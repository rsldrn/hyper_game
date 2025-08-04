using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager Instance;
    [Header("Elements")]
    [SerializeField] private LevelSelectionObject[] levels;
    
    [SerializeField] private GameObject finishLine;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    void Start()
    {
        GenerateLevels();
        finishLine = GameObject.FindWithTag("Finish");  
    }
    
    private void GenerateLevels()
    {
        int currentLevel = GetLevels();
        
        currentLevel = currentLevel % levels.Length;
        LevelSelectionObject level = levels[currentLevel];
        
        CreateLevels(level.chunks);
    }

    private void CreateLevels(Chunk[] levelChunks)
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < levelChunks.Length; i++)
        {
            Chunk chunkToCreate = levelChunks[i];
    
            if (i > 0)
            {
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }
    
            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    
    }

    public float GetFinishZ()
    {
        return finishLine.transform.position.z;
    }

    public int GetLevels()
    {
        return PlayerPrefs.GetInt("Level", 0);
    }
}

