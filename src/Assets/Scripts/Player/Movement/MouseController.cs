using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
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
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, Azimuth, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
