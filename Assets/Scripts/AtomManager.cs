using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomManager : MonoBehaviour {
	public int AtomId;
	public int AtomicNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		int otherId = other.GetComponent<AtomManager>().AtomId;
		GameObject.Find("Plane").GetComponent<AtomicBonds>().AddBond(AtomId, otherId);

		// GetChecker name
		WinChecker checker = WinChecker
			.GetChecker(GameObject.Find("Plane")
			.GetComponent<AtomicBonds>()
			.CheckerName);

		print(checker.CheckWin().ToString());
		if (checker.CheckWin())
        {
			ShowWinMessage();
        }
	}

	protected void ShowWinMessage()
	{
		GameObject.Find("WinnerText").GetComponent<Text>().text = "You Win!!!";
	}
}
