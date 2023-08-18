using UnityEngine;

public class TriggerZoomOutController : MonoBehaviour
{
	[SerializeField]
	private Collider ball;
	[SerializeField]
	private CameraController cameraController;

	private void OnTriggerEnter(Collider other)
	{
		if (other == ball)
		{
			cameraController.GoBackToDefault();
		}
	}
}
