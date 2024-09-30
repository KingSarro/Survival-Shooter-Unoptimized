﻿using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    //S.S
    private bool tryingToShoot = false;




    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }

    //S.S
    private void Start(){
        PlayerMovement.playerControls.Player.Shooting.started += OnPlayerShootStarted;
        PlayerMovement.playerControls.Player.Shooting.canceled += OnPlayerShootCanceled;;
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(tryingToShoot == true && timer >= timeBetweenBullets && Time.timeScale != 0){
            timer = 0f;

            gunAudio.Play ();

            gunLight.enabled = true;

            gunParticles.Stop ();
            gunParticles.Play ();

            gunLine.enabled = true;
            gunLine.SetPosition (0, transform.position);

            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
                if(enemyHealth != null)
                {
                    enemyHealth.TakeDamage (damagePerShot, shootHit.point);
                }
                gunLine.SetPosition (1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
            }
        }


		if(timer >= timeBetweenBullets * effectsDisplayTime){
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }





    //S.S
    //!!This might need to be in a different script
	private void OnPlayerShootStarted(InputAction.CallbackContext ctx){
        tryingToShoot = true;    
	}//OnShootPerformed func close
    private void OnPlayerShootCanceled(InputAction.CallbackContext ctx){
        tryingToShoot = false;    
	}//OnShootPerformed func close

}
