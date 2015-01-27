using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitInitInfo
{
	public Vector3 position;
}

public class UnitSystem : GameSystem {
	List<Unit> listUnit = new List<Unit>();
	Dictionary<int, Unit> dictUnit = new Dictionary<int, Unit>();
	int focusId = -1;
	
	public Unit CreateUnit(int id, UnitInitInfo info = null)
	{
		if (dictUnit.ContainsKey(id))
			return null;
		GameObject pref = Resources.Load<GameObject>("Prefabs/Cube");
		if (pref == null)
			return null;
		GameObject inst = null;
		if (info == null)
			inst = (GameObject)GameObject.Instantiate(pref);
		else
		{
			inst = (GameObject)GameObject.Instantiate(pref, info.position, Quaternion.identity);
		}
		if (inst == null)
			return null;
		Unit unit = inst.GetComponent<Unit>();
		if (unit == null)
			return null;
		unit.unitID = id;
		dictUnit[unit.unitID] = unit;
		listUnit.Add (unit);
		return unit;
	}
	
	public void RemoveUnit(int id)
	{
		if (dictUnit.ContainsKey(id))
		{
			Unit unit = dictUnit[id];
			GameObject.Destroy(unit.gameObject);
			listUnit.Remove(unit);
			dictUnit.Remove(id);
			if (focusId == id)
			{
				CameraController cc = Camera.main.GetComponent<CameraController>();
				cc.SetTargetObject(null);
			}
		}
	}
	
	public void SetUnitMotion(int id, Vector3 target, float speed)
	{
		if (dictUnit.ContainsKey(id))
		{
			Unit unit = dictUnit[id];
			unit.SetTarget(target);
			unit.SetSpeed(speed);
		}
	}
	
	public List<Unit> GetUnitList()
	{
		return listUnit;
	}
	
	public void SetCameraTarget(int id)
	{
		if (!dictUnit.ContainsKey(id))
			return;
		CameraController cc = Camera.main.GetComponent<CameraController>();
		if (cc == null)
			return;
		cc.SetTargetObject(dictUnit[id].gameObject);
		focusId = id;
	}
	
	public void StopMove(int id)
	{
		if (dictUnit.ContainsKey(id))
		{
			Unit unit = dictUnit[id];
			unit.SetTarget(unit.transform.position);
		}
	}
	
	public int GetFocusId()
	{
		return focusId;
	}
}
