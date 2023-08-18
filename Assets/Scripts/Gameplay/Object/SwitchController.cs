using System.Collections;
using UnityEngine;

public class SwitchController : MonoBehaviour
{

	private enum SwitchState
	{
		Off, 
		On,
		Blink
	}

	[SerializeField]
	private Collider ball;
	[SerializeField]
	private Material offMaterial;
	[SerializeField]
	private Material onMaterial;
	[SerializeField]
	private float score;

	[SerializeField]
	private AudioManager audioManager;
	[SerializeField]
	private VFXManager vfxManager;
	[SerializeField]
	private ScoreManager scoreManager;

	private SwitchState state;
	#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
	private Renderer renderer;


	private void Start()
	{
		renderer = GetComponent<Renderer>();

		Set(false);

		StartCoroutine(BlinkTimerStart(5));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other == ball)
		{
			Toggle();

			scoreManager.AddScore(score);
		}
	}

	private void Set(bool active)
	{

		if (active==true)
		{
			state = SwitchState.On;
			renderer.material = onMaterial;
			StopAllCoroutines();
		}
		else
		{
			state = SwitchState.Off;
			renderer.material = offMaterial;
			StartCoroutine(BlinkTimerStart(5));
		}

	}

	private void Toggle()
	{
		if (state == SwitchState.On)
		{
			//off
			Set(false); 
			audioManager.PlaySwitchSFX(transform.position, 0);
			vfxManager.PlaySwitchVFX(transform.position, 0);
		}
		else
		{
			//on
			Set(true);
			audioManager.PlaySwitchSFX(transform.position, 1);
			vfxManager.PlaySwitchVFX(transform.position, 1);
		}
	}

	private IEnumerator Blink(int times)
	{
		state = SwitchState.Blink;

		for (int i = 0; i < times; i++)
		{
			renderer.material = onMaterial;
			yield return new WaitForSeconds(0.5f);

			renderer.material = offMaterial;
			yield return new WaitForSeconds(0.5f);
		}

		state = SwitchState.Off;

		StartCoroutine(BlinkTimerStart(5));
	}

	private IEnumerator BlinkTimerStart(float time)
	{
		yield return new WaitForSeconds(time);
		StartCoroutine(Blink(2));
	}

}
