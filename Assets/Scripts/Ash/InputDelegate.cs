using UnityEngine;
using System.Collections;

public class PressEvent
{
	public int pressType;
	// 0 : Press
	// 1 : Release
	public Vector2 pressPosition;
}

public class InputDelegate : MonoBehaviour {
	static InputDelegate instance;
	InputSystem inputSystem;
	
	public static void SetInputSystem(InputSystem sys)
	{
		if (instance != null)
			instance.inputSystem = sys;
	}
	
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		instance = this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (inputSystem == null)
			return;
		
		if (Input.GetMouseButtonDown(0))
		{
			GameMsg msg = new GameMsg();
			PressEvent arg = new PressEvent();
			arg.pressType = 0;
			msg.arguement = arg;
			inputSystem.Receive(msg);
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			GameMsg msg = new GameMsg();
			PressEvent arg = new PressEvent();
			arg.pressType = 1;
			msg.arguement = arg;
			inputSystem.Receive(msg);
		}
		
		inputSystem.mousePosition = Input.mousePosition;
	}
}
