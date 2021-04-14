using UnityEngine;
using System.Collections;

public class Arma : MonoBehaviour {

	public GameObject projetilPrefabA;
	public GameObject projetilPrefabB;
	public GameObject projetilPrefabC;
	
	public float tempo;
	
	bool atirando;
	int tipoProjetil = 1;
	
	
	void Update () 
	{
		Atirar();
		MudarTiro();		
	}
	
	// Mudar tiro
	void MudarTiro()
	{
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			tipoProjetil++;
			
			if(tipoProjetil > 3)
			{
				tipoProjetil = 1;
			}
		}
		
	}
	
	void Atirar()
	{
		// Disparo por tempo / por intermitencia
		if(Input.GetKey(KeyCode.Space) && !atirando)
		{
			atirando = true;
			StartCoroutine(Disparo());			
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			CriarProjetil();
		}
	}
	
		
	// Tiro por temporizador
	IEnumerator Disparo()
	{	
		CriarProjetil();
		yield return new WaitForSeconds(tempo);
		atirando = false;		
	}
	
	// Cria projetil
	void CriarProjetil()
	{
		if(tipoProjetil == 1)
		{
			Instantiate(projetilPrefabA, transform.position, transform.rotation);
		}
		else if(tipoProjetil == 2)
		{
			Instantiate(projetilPrefabB, transform.position, transform.rotation);
		}
		else if(tipoProjetil == 3)
		{
			Instantiate(projetilPrefabC, transform.position, transform.rotation);
		}
	}
	
	
}
