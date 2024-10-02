using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour{

	//S.S
	public static PlayerControls playerControls;
	int animID_IsWalking = Animator.StringToHash("IsWalking");

	//hehehe (;


	public float speed = 6f;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;

	private void OnEnable(){
		playerControls.Enable();
	}
	private void OnDisable(){
		playerControls.Disable();
	}

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();


		//S.S
		playerControls = new PlayerControls();
	}

	private void Start(){
		playerControls.Player.Movement.performed += OnPlayerMovementPerformed;
	}

	void FixedUpdate(){

		Move(); //Took out the h and v variables
		Turning();
		Animating(movement); //Switched from the h and v variables to the vector
	}

	void Move(){
		//got rid of the set movement because the movement is being read and set on perform
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(Vector3 movement)
	{
		bool walking = (movement != Vector3.zero); //Changed to check if the movement is not zero

		anim.SetBool(animID_IsWalking, walking);
	}

	//S.S

	//created to get the performed movement
	private void OnPlayerMovementPerformed(InputAction.CallbackContext ctx){
		movement = ctx.ReadValue<Vector3>();
	}
	//created to get the cancelled movement
	private void OnPlayerMovementCancelled(InputAction.CallbackContext ctx){
		movement = Vector3.zero;
	}

	






}
