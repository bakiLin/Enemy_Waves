using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public int enemyAmount;

    public GameObject[] enemyPrefab;

    public Vector3[] spawnPosition;
}
