using UnityEngine;
using System.Collections;

public class RootSystemTest : MonoBehaviour {
	public UnitSystem unitSystem;
	static RootSystemTest inst;
	
	int id = 0;
	Vector3 target;
	
	public static void SetSystem(UnitSystem sys)
	{
		if (inst == null) return;
		inst.unitSystem = sys;
	}
	
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		inst = this;
	} 
	
	void OnGUI()
	{
		if (unitSystem == null)
		{
			GUILayout.Label("unitSystem == null");
			return;
		}
		
		try
		{
			id = int.Parse(GUILayout.TextArea(id.ToString()));
			float x = float.Parse(GUILayout.TextArea(target.x.ToString()));
			float y = float.Parse(GUILayout.TextArea(target.y.ToString()));
			float z = float.Parse(GUILayout.TextArea(target.z.ToString()));
			target = new Vector3(x, y, z);
		}
		catch (System.Exception ex)
		{
		
		}
		if (GUILayout.Button("Create"))
			unitSystem.CreateUnit(id);
		if (GUILayout.Button("Remove"))
			unitSystem.RemoveUnit(id);
		if (GUILayout.Button("Move"))
			unitSystem.SetUnitMotion(id, target, 1.0f);
		if (GUILayout.Button("SetFocus"))
			unitSystem.SetCameraTarget(id);
		if (GUILayout.Button ("Stop"))
			unitSystem.StopMove(id);
		
		foreach (Unit unit in unitSystem.GetUnitList())
		{
			GUILayout.Label (unit.unitID.ToString());
		}
	}
}
