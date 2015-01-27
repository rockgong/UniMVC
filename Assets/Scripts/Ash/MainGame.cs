using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

	void Awake()
	{
		MainController.StaticInit();
	}
	// Use this for initialization
	void Start () {
		RootSystemTest.SetSystem(MainController.GetUnitSystem());
		InputDelegate.SetInputSystem(MainController.GetInputSystem());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
