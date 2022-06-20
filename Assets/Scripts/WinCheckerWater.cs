using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WinCheckerWater : WinChecker
{
    public override bool CheckWin()
    {
        List<int>[] bonds = GameObject.Find("Plane").GetComponent<AtomicBonds>().bonds;

        GameObject oxygen = GetAtomsByNumber(8).FirstOrDefault();

        if (oxygen == null)
        {
            return false;
        }

        int oxyId = oxygen.GetComponent<AtomManager>().AtomId;

        print("Oxy: " + oxyId);

        int countHydrogen = 0;
        for(int i = 0; i < bonds[oxyId].Count; i++)
        {
            if (GetAtomById(bonds[oxyId][i]).GetComponent<AtomManager>().AtomicNumber == 1)
            {
                countHydrogen++;
            }
        }
        return countHydrogen == 2 ? true : false;
    }

}
