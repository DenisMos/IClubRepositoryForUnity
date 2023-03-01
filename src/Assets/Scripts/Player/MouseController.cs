using UnityEngine;

public class MouseController : MonoBehaviour
{
	private float _camSens = 0.25f; //How sensitive it with mouse
	private Vector3 _lastMouse = new Vector3(255, 255, 255);

	void Update()
	{
		//Это API Unity которое помогает определить движения по осям X и Y.
		var x = Input.GetAxis("Mouse X");
		var y = Input.GetAxis("Mouse Y");

		//Это оптимизация множественного пересоздания вектора.
		var compX = -y * _camSens;
		var compY = x * _camSens;

		_lastMouse = new Vector3(transform.eulerAngles.x + compX, transform.eulerAngles.y + compY, 0);
		transform.eulerAngles = _lastMouse;
		_lastMouse = Input.mousePosition;

		//Первое - огранич движение по Y
		//Второе - расширь движение по X
		//Создай зависимость между поворотом камеры и персонажа
	}
}
