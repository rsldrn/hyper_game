using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Object/Level", order = 0)]
public class LevelSelectionObject : ScriptableObject
{
    public Chunk[] chunks;
}
