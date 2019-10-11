using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour {

	public void LoadScene(string seneName) {
		SceneManager.LoadScene(seneName);
	}
}
