using UnityEngine;

public class TriggerZoomInController : MonoBehaviour
{
	[SerializeField]
	private Collider ball;
	[SerializeField]
	private CameraController cameraController;
	[SerializeField]
	private float length;

	private void OnTriggerEnter(Collider other)
	{
		if (other == ball)
		{
			cameraController.FollowTarget(ball.transform, length);
		}
	}
}
