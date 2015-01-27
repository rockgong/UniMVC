using UnityEngine;
using System.Collections;

public class InputSystemTest : MonoBehaviour {
	DummySystem ds = new DummySystem();
	InputSystem ic = new InputSystem();
	void Awake()
	{
		
	}
	// Use this for initialization
	void Start () {
		InputDelegate.SetInputSystem(ic);
		ic.parentSystem = ds;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{
		GUILayout.Label(ic.mousePosition.ToString());
	}
}
