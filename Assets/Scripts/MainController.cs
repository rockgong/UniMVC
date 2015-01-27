using UnityEngine;
using System.Collections;

public class MainController {
	StageSystem stageSystem;
	UnitSystem unitSystem;
	InputSystem inputSystem;
	
	static MainController inst;
	
	public static void StaticInit()
	{
		inst = new MainController();
		inst.Init();
	}
	
	public static UnitSystem GetUnitSystem()
	{
		return inst.unitSystem;
	}
	
	public static InputSystem GetInputSystem()
	{
		return inst.inputSystem;
	}
	
	public void Init()
	{
		stageSystem = new StageSystem();
		unitSystem = new UnitSystem();
		inputSystem = new InputSystem();
		stageSystem.unitSystem = unitSystem;
		stageSystem.inputSystem = inputSystem;
		unitSystem.parentSystem = stageSystem;
		inputSystem.parentSystem = stageSystem;
	}
}
