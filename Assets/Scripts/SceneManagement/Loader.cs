using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
	private class LoadingMonoBehaviour : MonoBehaviour { }

	public enum Scene {
		MainMenu,
		Level1,
		Level2,
		Level3,
		Level4,
		Level5,
		Level6,
		Level7,
		Level8,
		Level9,
		Level10,
		Level11,
		Level12,
		Level13,
		Level14,
		Level15,
		Level16,
		Level17,
		Level18,
		Level19,
		Level20,
		Level21,
		Level22,
		Level23,
		Level24,
		Level25,
		Level26,
		Level27,
		Level28,
		Level29,
		Level30,
		Level31,
		Level32,
		Level33,
		Level34,
		Level35,
		Level36,
		Level37,
		Level38,
		Level39,
		Level40,
		Loading,
		LevelMenu,
	}

	private static Action onLoaderCallBack;
	private static AsyncOperation loadingAsyncOperation;

	public static void Load(Scene scene) {
		onLoaderCallBack = () => {
			GameObject loadingGameObject = new GameObject("Loading Game Object");
			loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
		};

		SceneManager.LoadScene(Scene.Loading.ToString());
	}

	private static IEnumerator LoadSceneAsync(Scene scene) {
		yield return null;

		loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

		while (!loadingAsyncOperation.isDone) {
			yield return null;
		}
	}

	public static float GetLoadingProgress() {
		if (loadingAsyncOperation != null) {
			return loadingAsyncOperation.progress;
		} else {
			return 1f;
		}
	}

	public static void LoaderCallBack() {
		if (onLoaderCallBack != null) {
			onLoaderCallBack();
			onLoaderCallBack = null;
		}
	}
}
