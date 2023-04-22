using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;
using UnityEngine.Networking.Options;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{
	[SerializeField]
	private CharacterController controller;
	
	[SerializeField]
	private float speed = 12f;
	
	[SerializeField]
	private float gravity = -9.81f;
	
	[SerializeField]
	private float jumpHeight = 3f;
	
	[SerializeField]
	private LayerMask groundMask;

	private Vector3 Velocity;
	private bool isGrounded;

	[SerializeField]
	private float _modDirect = 1f;

	[SerializeField]
	private float _Stamina = 100f;

	public Text _text;

	// Update is called once per frame
	void Update()
	{
		if(NetworkOptions.Mode != 0 && !IsLocalPlayer)
		{
			return;
		}

		isGrounded = controller.isGrounded;

		if(isGrounded && Velocity.y < 0)
		{
			Velocity.y = -2f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		controller.Move(move * speed * Time.deltaTime * _modDirect);

		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			Velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		_text.text = _Stamina.ToString();

		Velocity.y += gravity * Time.deltaTime;
		controller.Move(Velocity * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.LeftShift))
        {
			speed = 20f;
			_Stamina -= Time.deltaTime;
        }
		else
		{
			speed = 12f;
		}
	}

	[SerializeField]
	private Vector3 _spawnPosition;

	protected void Start()
	{
		GetComponent<CharacterController>().enabled = false;
		Debug.Log("Spawn");
		transform.position = _spawnPosition;
		Debug.Log(transform.position);
		GetComponent<CharacterController>().enabled = true;
		_text = GameObject.FindGameObjectWithTag("TextStamina").GetComponent<Text>();
		_Stamina = 100;
	}
}
