using UnityEngine;

public class EnemyHealth : MonoBehaviour{
    [SerializeField] private EnemyStats stats;
    private EnemySpawner eSpawner;




    public int currentHealth;
    public AudioClip deathClip;

    //S.S
    [SerializeField] ScoreStats playerScore;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    //S.S
    int animID_Dead = Animator.StringToHash("Dead");


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = stats.GetStartingHealth();
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * stats.GetSinkSpeed() * Time.deltaTime);
        }
    }

    public void ResetHealth(){
        currentHealth = stats.GetStartingHealth();
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger (animID_Dead);

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ////ScoreManager.score += scoreValue;
        playerScore.IncreaseScore(stats.GetScoreValue());
        ////Destroy (gameObject, 2f);
        ///
        if(gameObject.name == "Zombunny(Clone)"){
            GameObject.Find("ZomBunnySpawnPoint").GetComponent<EnemySpawner>().enemyPool.Release(this);
        }
        else if(gameObject.name == "ZomBear(Clone)"){
            GameObject.Find("ZomBearSpawnPoint").GetComponent<EnemySpawner>().enemyPool.Release(this);
        }
        else if(gameObject.name == "Hellephant(Clone)"){
            GameObject.Find("HelephantSpawnPoint").GetComponent<EnemySpawner>().enemyPool.Release(this);
        }




        eSpawner.enemyPool.Release(this); //S.S
    }
}
