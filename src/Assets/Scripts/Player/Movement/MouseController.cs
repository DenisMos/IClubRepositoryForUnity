using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MouseController : NetworkBehaviour
{
	#region Fields

	[SerializeField]
    private float mouseSensetivity = 100f;
	[SerializeField]
	private Transform playerBody;
	[SerializeField]
	private float Azimuth = 180;

	#endregion

	#region Data
	private float xRotation = 0f;
	#endregion

	// Start is called before the first frame update
	void Start()
    {
		if(!IsLocalPlayer)
		{
			transform.GetComponent<Camera>().enabled = false;
			transform.GetComponent<AudioListener>().enabled = false;
		}

		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsLocalPlayer)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, Azimuth, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
