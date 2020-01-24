using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public GameObject tpIN;
	public GameObject tpOUT;
	Color oldColor1;
	Color oldColor2;

	void Start()
	{
		oldColor1 = tpOUT.GetComponent<SpriteRenderer>().color ;
		oldColor2 = tpIN.GetComponent<SpriteRenderer>().color ;
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		if (this.name == "teleportIN")
		{
			tpOUT.GetComponent<Collider2D>().enabled = false;
			tpOUT.GetComponent<SpriteRenderer>().color = new Color(100f, 90f, 125f);
			col.transform.position = tpOUT.transform.position;
			StartCoroutine(Timer(0));
		}
		else
		{
			tpIN.GetComponent<Collider2D>().enabled = false;
			tpIN.GetComponent<SpriteRenderer>().color = new Color(100f, 90f, 125f);
			col.transform.position = tpIN.transform.position;
			StartCoroutine(Timer(1));
		}
    }

	IEnumerator Timer(int i)
    {
		yield return new WaitForSeconds(3);
		if (i == 0)
		{
			tpOUT.GetComponent<Collider2D>().enabled = true;
			tpOUT.GetComponent<SpriteRenderer>().color = oldColor1;
		}
		else
		{
			tpIN.GetComponent<Collider2D>().enabled = true;
			tpIN.GetComponent<SpriteRenderer>().color = oldColor2;
		}
    }
}
