using UnityEngine;
using System.Collections;

public class Projetil : MonoBehaviour {

	public float velocidade;
	public float limite;
	

	void Update () 
	{		
		MoverProjetil();
	}
	
	// Move o projetil 
	void MoverProjetil()
	{
		transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
		
		// Destruir projetil quando chegar em seu limite
		if(transform.position.z >= limite)
		{
			Destroy(gameObject);
		}
	}
	
	
	void OnCollisionEnter(Collision colisao)
	{
		Destroy(gameObject);
	}
	
	
	
}
