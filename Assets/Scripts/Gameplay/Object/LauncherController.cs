using System.Collections;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
	[SerializeField]
	private Collider ball;
	[SerializeField]
	private KeyCode launchKey;

	[SerializeField]
	private float maxTimeHold;
	[SerializeField]
	private float maxForce;

	[SerializeField]
	private Material onMaterial;
	[SerializeField]
	private Material offMaterial;

	private bool isHold = false;
	private Renderer _renderer;

	private void Start()
	{
		_renderer = GetComponent<Renderer>();
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider == ball)
		{
			ReadInput(ball);
		}
	}

	private void ReadInput(Collider collider)
	{
		if (Input.GetKeyDown(launchKey) && !isHold)
		{
			StartCoroutine(StartHold(collider));
		}
	}

	private IEnumerator StartHold(Collider collider)
	{
		isHold = true;
		_renderer.material = onMaterial;

		float force = 0.0f;
		float timeHold = 0.0f;

		while (Input.GetKey(launchKey))
		{
			force = Mathf.Lerp(0.0f, maxForce, timeHold / maxTimeHold);

			yield return new WaitForEndOfFrame();
			timeHold += Time.deltaTime;
		}

		collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
		isHold = false;
		_renderer.material = offMaterial;
	}
}
