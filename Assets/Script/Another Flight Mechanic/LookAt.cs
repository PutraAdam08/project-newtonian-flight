using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
	public Transform lookAt;

	private void Update()
	{
		if (lookAt != null)
		{
			transform.LookAt(lookAt);
		}
	}
}
