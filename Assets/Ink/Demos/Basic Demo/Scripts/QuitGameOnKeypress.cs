<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;

public class QuitGameOnKeypress : MonoBehaviour {
	
	public KeyCode key = KeyCode.Escape;
	
	void Update () {
		if(Input.GetKeyDown(key)) Application.Quit();
	}
=======
﻿using UnityEngine;
using System.Collections;

public class QuitGameOnKeypress : MonoBehaviour {
	
	public KeyCode key = KeyCode.Escape;
	
	void Update () {
		if(Input.GetKeyDown(key)) Application.Quit();
	}
>>>>>>> Programming
}