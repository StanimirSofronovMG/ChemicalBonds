using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AtomicBonds : MonoBehaviour 
{
	[System.NonSerialized]
	public List<int>[] bonds;
	public string CheckerName;

	// Use this for initialization
	void Start () {
		// Get atom count
		int nAtoms = GameObject.Find("Atoms").transform.childCount;
		bonds = new List<int>[nAtoms];

		int i = 0;
		GameObject[] atoms = GameObject.Find("Atoms").GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();

		foreach(GameObject obj in atoms.Skip(1))
        {
			obj.GetComponent<AtomManager>().AtomId = i;
			bonds[i] = new List<int>();
			i++;
        }
	}

	public void AddBond(int id1, int id2)
    {
		if (bonds[id1].Contains(id2) == false)
        {
			bonds[id1].Add(id2);
			bonds[id2].Add(id1);
        }
    }

	public void RemoveBond(int id1, int id2)
    {
		if (bonds[id1].Contains(id2))
        {
			bonds[id1].Remove(id2);
			bonds[id2].Remove(id1);
        }
    }

	protected List<GameObject> GetAtomsByNumber(int AtomicNumber)
    {
		return GameObject.Find("Atoms").GetComponentsInChildren<Transform>()
			.Where(c => c.gameObject.GetComponent<AtomManager>().AtomicNumber.Equals(AtomicNumber))
			.Select(c => c.gameObject).ToList();
    }
}
