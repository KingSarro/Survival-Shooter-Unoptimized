using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    public EnemySpawner eSpawner;


    void Start (){
        InvokeRepeating ("SpawnZombies", spawnTime, spawnTime);
    }


    //Spawn Zombies... S.S
    private void SpawnZombies(){
        eSpawner.enemyPool.Get();
    }











    void Spawn ()
    {
        if(playerHealth.playerStats.GetCurrentHealth() <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
