using UnityEngine;

/// <summary>Класс отвечающий за движение.</summary>
public class Movement : MonoBehaviour
{
	private CharacterController _controller;
	private Vector3 _playerVelocity;
	private bool _groundedPlayer;
	private float _playerSpeed = 10.0f;
	private float _jumpHeight = 1.0f;
	private float _gravityValue = -9.81f;

	private void Start()
	{
		_controller = gameObject.GetComponent<CharacterController>();
	}

	void Update()
	{
		//controller.Move(Vector3.forward * Time.deltaTime);

		_groundedPlayer = _controller.isGrounded;
		if (_groundedPlayer && _playerVelocity.y < 0)
		{
			_playerVelocity.y = 0f;
		}

		//Движение
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//transform.TransformDirection - функция которая позволяет переводить глобальные координаты в локальные
		_controller.Move(transform.TransformDirection(move * Time.deltaTime * _playerSpeed));

		// jump
		if (Input.GetButtonDown("Jump") && _groundedPlayer)
		{
			_playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
		}

		//Гравитация
		_playerVelocity.y += _gravityValue * Time.deltaTime;
		_controller.Move(_playerVelocity * Time.deltaTime);
	}
}
