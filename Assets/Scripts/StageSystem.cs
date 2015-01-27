using UnityEngine;
using System.Collections;

public class StageSystem : GameSystem {
	public UnitSystem unitSystem;
	public InputSystem inputSystem;
	
	public override void Receive(GameMsg msg)
	{
		object arg = msg.arguement;
		if (arg is InputEvent)
		{
			InputEvent ie = arg as InputEvent;
			OnInput(ie.inputType, inputSystem.mousePosition);
		}
	}
	
	void OnInput(int type, Vector2 pos)
	{
		if (type == 0)
		{
			Ray ray = Camera.main.ScreenPointToRay (pos);
			RaycastHit hitInfo;
			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
			{
				unitSystem.SetUnitMotion(unitSystem.GetFocusId(), hitInfo.point, 5.0f);
			}
		}
	}
}
