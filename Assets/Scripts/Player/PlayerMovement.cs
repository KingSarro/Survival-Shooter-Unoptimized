using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour{

	//Shari was here!
	private PlayerControls playerControls;

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

	void FixedUpdate()
	{
		////float h = Input.GetAxisRaw("Horizontal");
		////float v = Input.GetAxisRaw("Vertical");

		Move();
		Turning();
		Animating(movement);
	}

	void Move()
	{
		////movement.Set(h, 0f, v);
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
		bool walking = (movement != Vector3.zero);

		anim.SetBool("IsWalking", walking);
	}

	//S.S
	private void OnPlayerMovementPerformed(InputAction.CallbackContext ctx){
		movement = ctx.ReadValue<Vector3>();
	}
	private void OnPlayerMovementCancelled(InputAction.CallbackContext ctx){
		movement = Vector3.zero;
	}

	//!!This might need to be in a different script
	private void OnPlayerShootPerformed(InputAction.CallbackContext ctx){
		//Button read
	}






}
