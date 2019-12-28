using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScript : MonoBehaviour
{
	public GameObject[] door;
	int choice;
	Color color;
	bool open = false;

	void OnTriggerEnter2D(Collider2D col)
    {
		if (open == false)
		{
			if (col.name == "Thomas")
			{
				choice = 0;
				color = new Color(230f, 0f, 0f); //red
			}

			if (col.name == "John")
			{
				choice = 1;
				color = new Color(255f, 242f, 0f); //yellow
			}

			if (col.name == "Claire")
			{
				choice = 2;
				color = new Color(0f, 0f, 255f); //blue
			}

			door[choice].transform.position += new Vector3(0, 2, 0);
			this.GetComponent<SpriteRenderer>().color = color;
			open = true;
		}
		else
		{
			door[choice].transform.position += new Vector3(0, -2, 0);
			this.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f); //white
			open = false;
		}
    }
}
