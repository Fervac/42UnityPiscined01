using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
	public GameObject[] door;
	int choice;
	Color color;
	bool open = false;

	void OnTriggerEnter2D(Collider2D col)
    {
		if (open == false)
		{
			if (col.CompareTag("Thomas"))
			{
				choice = 0;
				color = new Color(230f, 0f, 0f); // Red
			}

			if (col.CompareTag("John"))
			{
				choice = 1;
				color = new Color(255f, 242f, 0f); // Yellow
			}

			if (col.CompareTag("Claire"))
			{
				choice = 2;
				color = new Color(0f, 0f, 255f); // Blue
			}

			door[choice].transform.position += new Vector3(0, 2, 0);
			this.GetComponent<SpriteRenderer>().color = color;
			open = true;
		}
		else
		{
			door[choice].transform.position += new Vector3(0, -2, 0);
			this.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f); // White
			open = false;
		}
    }
}
