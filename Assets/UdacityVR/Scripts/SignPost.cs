using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignPost : MonoBehaviour {

	public void ResetScene () {
		// Prints to the console when the method is called
		Debug.Log ("'SignPost.ResetScene()' was called");

		// Reload the scene
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene (scene.name);
	}
}
