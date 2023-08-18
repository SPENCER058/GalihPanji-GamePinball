using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
	[SerializeField]
	private Button mainMenuButton;

	private void Start ()
	{
		mainMenuButton.onClick.AddListener(MainMenu);
	}

	private void MainMenu ()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
