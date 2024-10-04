using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour{
    //Initializing variables

    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private int maxEnemySpawn;
    [SerializeField] private Transform spawnerTransform;

    //
    [SerializeField] private EnemyManager enemyManager;
    
    //
    public ObjectPool<EnemyHealth> enemyPool;
    
    
    private void Start(){
        enemyPool = new ObjectPool<EnemyHealth>(CreateEnemy, ActivateEnemy, DeactivateEnemy, DestroyEnemy, true, maxEnemySpawn, maxEnemySpawn*2);
    }//Closes Start Method


    private EnemyHealth CreateEnemy(){
        var enemy = Instantiate(enemyToSpawn, spawnerTransform);
        enemy.transform.SetParent(spawnerTransform);
        enemy.gameObject.SetActive(false);

        return enemy.GetComponent<EnemyHealth>();
    }//Closes the createEnemy method

    private void ActivateEnemy(EnemyHealth enemyH){
        enemyH.gameObject.SetActive(true);
    }//Closes the Activate Enemy

    private void DeactivateEnemy(EnemyHealth enemyH){
        enemyH.gameObject.SetActive(false);
        enemyH.gameObject.transform.position = spawnerTransform.position;
        enemyH.gameObject.GetComponent<EnemyHealth>().ResetHealth();
    }//Closes the DeactivateEnemy

    private void DestroyEnemy(EnemyHealth enemyH){
        Destroy(enemyH.gameObject);
    }//closes the DestroyEnemy


















}
