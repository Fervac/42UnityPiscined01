using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript_ex00 : MonoBehaviour
{
	public float jump = 4.5f;
	public float move = 1.5f;
	public int choice = 0;
	public bool change = false;
	public bool win = false;
	public Rigidbody2D[] rb;

	void FixedUpdate()
	{
		if (Input.GetKeyDown("space") && rb[choice].velocity.y == 0.0f)
		{
			rb[choice].velocity = new Vector2(0.0f, jump);
		}

		if (Input.GetKey("d"))
		{
			rb[choice].velocity = new Vector2(move, 0.0f);
		}

		if (Input.GetKey("q"))
		{
			rb[choice].velocity = new Vector2(-move, 0.0f);
		}
	}

    void Update()
    {
		if (change == true)
		{
			foreach (Rigidbody2D rbs in rb)
			{
				rbs.velocity = new Vector2(0.0f, 0.0f);
			}
			for (int i = 0; i < rb.Length; i++)
			{
				if (i != choice)
				{
					rb[i].isKinematic = true;
				}
				else
				{
					rb[i].isKinematic = false;
				}
			}
			change = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		if (col.CompareTag(rb[choice].tag))
		{
			win = true;
		}
    }

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.CompareTag("Platform"))
		{
			rb[choice].transform.parent = col.transform;
		}

		if(col.CompareTag("Claire"))
		{
			rb[choice].transform.parent = col.transform;
		}
	}

	void OnTriggerExit2D(Collider2D col)
    {
		if (col.CompareTag(rb[choice].tag))
		{
			win = false;
		}

		if(col.CompareTag("Platform"))
		{
			rb[choice].transform.parent = null;
		}

		if(col.CompareTag("Claire"))
		{
			rb[choice].transform.parent = null;
		}
    }

}
