using UnityEngine;
using System.Collections;

public class btnClick : MonoBehaviour 
{
	Ray ray;
	RaycastHit hit;

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray, out hit))
			{
				if(hit.collider.tag == "btniniciar")
				{
					Application.LoadLevel("game");
				}
				else if(hit.collider.tag == "face")
				{
					Application.OpenURL("htpp://www.facebook.com");
				}
			}
		}
		
	}
}
