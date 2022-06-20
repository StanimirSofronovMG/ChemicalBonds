using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class WinChecker : MonoBehaviour {

	public abstract bool CheckWin();

	protected List<GameObject> GetAtomsByNumber(int AtomicNumber)
	{
		print(GameObject.Find("Atoms").name);
		return GameObject.Find("Atoms").GetComponentsInChildren<Transform>().Skip(1)
			.Where(c => c.gameObject.GetComponent<AtomManager>().AtomicNumber.Equals(AtomicNumber))
			.Select(c => c.gameObject).ToList();
	}

	protected static GameObject GetAtomById(int AtomId)
    {
		return GameObject.Find("Atoms").GetComponentsInChildren<Transform>().Skip(1)
			.Where(c => c.gameObject.GetComponent<AtomManager>().AtomId.Equals(AtomId))
			.Select(c => c.gameObject).FirstOrDefault();
	}

	public static WinChecker GetChecker(string Name) 
	{ 
		if (Name == "Water")
        {
			return new WinCheckerWater();
        }
		else
        {
			throw new System.Exception();
        }
	}
}
