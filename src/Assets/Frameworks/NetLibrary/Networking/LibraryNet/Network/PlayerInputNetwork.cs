using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerInputNetwork : MonoBehaviour
{
    private StarterAssetsInputs _inupts;
	private NetworkObject _net;

    [SerializeField]
    private float speedX = 200;
	[SerializeField]
	private float speedY = 200;

	[SerializeField]
	private float _speedMove = 10;

	private void Start()
    {
        _inupts = GetComponent<StarterAssetsInputs>();
		_net = GetComponent<NetworkObject>();

	}

    private void OnMouse()
    {
		float h = Input.GetAxis("Mouse X") * speedX;
		float v = Input.GetAxis("Mouse Y") * speedY;

		_inupts.LookInput(new Vector2(h, -v));
	}

	private void OnMove()
	{
		float h = Input.GetAxis("Horizontal") * _speedMove;
		float v = Input.GetAxis("Vertical")   * _speedMove;

		_inupts.MoveInput(new Vector2(h, v));
	}

	private void OnJump()
	{
		var jump = Input.GetButton("Jump");

		_inupts.JumpInput(jump);
	}

	private void OnShift()
	{
		var jump = Input.GetButton("Shift");

		_inupts.SprintInput(jump);
	}

	private void Update()
    {
		if(_net.IsOwner)
		{
			OnMouse();
			OnMove();
			OnJump();
			OnShift();
		}
	}
}
