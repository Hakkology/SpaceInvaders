using UnityEngine;

[CreateAssetMenu(fileName = "InvaderGridData", menuName = "GameData/InvaderGridData")]
public class InvaderGridData : ScriptableObject
{
    [Header("Enemy Spawn Grid")]
    public Invader[] prefabs; // Different types of invaders
    public int rows = 5;
    public int columns = 11;
    public float rowSpan = 2.0f;
    public float columnSpan = 2.0f;
    public float gridOffset = 3.0f;
}
