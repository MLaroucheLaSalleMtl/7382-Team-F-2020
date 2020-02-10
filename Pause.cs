using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
	public GameObject pause;
	public bool isPaused = false;
	public GameObject GameStartPanel;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//dis.SetActive(false);
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			if (isPaused)
			{
				ResumeGame();
			}
			else
			{
				pause.SetActive(true);
				Time.timeScale = 0f;
				isPaused = true;
				//if (Input.GetMouseButtonDown(0))
				//{
				//	GameObject.FindGameObjectWithTag("BackToMenu");
				//	ResumeGame();
				//}
			}
		}
	}

	public void ResumeGame()
	{
		//dis.SetActive(true);
		pause.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	public void Mainmenu()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		SceneManager.LoadScene("Game");
	}

	public void StartGame()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		Time.timeScale = 0f;
		GameStartPanel.SetActive(false);
		ResumeGame();
	}
}
