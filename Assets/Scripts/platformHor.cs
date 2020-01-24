using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHor : MonoBehaviour
{
	Vector2 startPosition;
	Vector2 newPosition;
	int speed = 3;
	int maxDistance = 1;

	void Start()
	{
	    startPosition = transform.position;
	    newPosition = transform.position;
	}

	void Update()
	{
	    newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * speed));
	    transform.position = newPosition;
	}
}
