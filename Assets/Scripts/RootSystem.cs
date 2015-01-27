using UnityEngine;
using System.Collections;

public class RootSystem : GameSystem {
	UnitSystem unitSystem;
	
	public void SetUnitSystem(UnitSystem system)
	{
		unitSystem = system;
	}
}
