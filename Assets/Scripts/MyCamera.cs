using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
	public GameObject[] player;
    private Vector3 offset;
	int choice = 0;

	PlayerScript_ex00 script;

    void Start()
    {
        offset = transform.position - player[choice].transform.position;
		script = player[choice].GetComponent<PlayerScript_ex00>();

		for (int i = 0; i < script.rb.Length; i++)
		{
			if (i != 0)
			{
				script.rb[i].isKinematic = true;
			}
			else
			{
				script.rb[i].isKinematic = false;
			}
		}

		for (int i = 10; i < 10 + player.Length; i++)
		{
			if (i != 10 + choice)
			{
				Physics2D.IgnoreLayerCollision(0, i);
			}
			else
			{
				Physics2D.IgnoreLayerCollision(0, i, false);
			}
		}
    }

	void Update()
	{
		Select();

		if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
		{
			Reload();
		}

		transform.position = Vector3.Lerp(transform.position, player[choice].transform.position + offset, .5f);

		if (CheckWin() == true)
		{
			NextLevel();
		}
	}

	void Select()
	{
		if (Input.GetKeyDown("1"))
		{
			choice = 0;
			Enable();
			script.move = 1.2f;
			script.jump = 4.5f;
		}

		if (Input.GetKeyDown("2"))
		{
			choice = 1;
			Enable();
			script.move = 1.4f;
			script.jump = 5.5f;
		}

		if (Input.GetKeyDown("3"))
		{
			choice = 2;
			Enable();
			script.move = 1.0f;
			script.jump = 4f;
		}
	}

	void Enable()
	{
		for (int i = 0; i < player.Length; i++)
		{
			if (i != choice)
			{
				player[i].GetComponent<PlayerScript_ex00>().enabled = false;
			}
			else
			{
				player[i].GetComponent<PlayerScript_ex00>().enabled = true;
			}
		}

		for (int i = 10; i < 10 + player.Length; i++)
		{
			if (i != 10 + choice)
			{
				Physics2D.IgnoreLayerCollision(0, i);
			}
			else
			{
				Physics2D.IgnoreLayerCollision(0, i, false);
			}
		}

		script = player[choice].GetComponent<PlayerScript_ex00>();
		script.choice = choice;
		script.change = true;
	}

	void Reload()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	bool CheckWin()
	{
		for (int i = 0; i < player.Length; i++)
		{
			if (player[i].GetComponent<PlayerScript_ex00>().win == false)
			{
				return (false);
			}
		}
		return (true);
	}

	void NextLevel()
	{
		Debug.Log("YOU WIN!");

		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(sceneBuildIndex:scene+1);
	}
}
