using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    [SerializeField] private float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField] private EnemySpawner eSpawner;


    void Start (){
        InvokeRepeating ("SpawnZombies", spawnTime, spawnTime);
    }


    //Spawn Zombies... S.S
    private void SpawnZombies(){
        eSpawner.enemyPool.Get();
    }

    public EnemySpawner GetSpawnerReference(){
        return eSpawner;
    }








}
