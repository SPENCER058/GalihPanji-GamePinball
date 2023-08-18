using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
	[SerializeField]
	private Button playButton, creditButton, exitButton;

	private void Start ()
	{
		playButton.onClick.AddListener(() => loadScene("PinBall_Gameplay"));
		creditButton.onClick.AddListener(() => loadScene("Credits"));
		exitButton.onClick.AddListener(ExitButton);
	}

	private void loadScene (string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	private void ExitButton ()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
