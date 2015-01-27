using UnityEngine;
using System.Collections;

public class InputEvent
{
	public int inputType;
	//0, press
	//1, release
	
	public override string ToString()
	{
		return string.Format("inputType={0}", inputType.ToString());
	}
}

public class InputSystem : GameSystem{
	public Vector2 mousePosition;
	
	public override void Receive(GameMsg msg)
	{
		PressEvent arg = msg.arguement as PressEvent;
		if (arg != null)
		{
			InputEvent evt = new InputEvent();
			evt.inputType = arg.pressType;
			GameMsg msg0 = new GameMsg();
			msg0.arguement = evt;
			Send(msg0);
		}
	}
}
