﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	private AsyncOperation asy;

	public void BtnLoadScene()
	{
		if (asy == null)
		{
			Scene currScene = SceneManager.GetActiveScene();
			asy = SceneManager.LoadSceneAsync(currScene.buildIndex + 1);
			asy.allowSceneActivation = true;
		}
	}

	public void BtnLoadScene(int i)
	{
		if (asy == null)
		{

			asy = SceneManager.LoadSceneAsync(i);
			asy.allowSceneActivation = true;
		}
	}

	public void BtnLoadScene(string s)
	{
		//Cursor.visible = true;
		if (asy == null)
		{
			asy = SceneManager.LoadSceneAsync(s);
			asy.allowSceneActivation = true;
		}
	}
}
