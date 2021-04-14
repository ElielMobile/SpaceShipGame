using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {
	
	public float velocidadeMin, velocidadeMax;
	public int velocidadeFinal;
	public float limite;
	public GameObject explosao, faisca;

	int vidaInimigo;
		

	// Use this for initialization
	void Start () 
	{
	 	velocidadeFinal = Random.Range((int)velocidadeMin,(int)velocidadeMax);
	 	
	 	// Atribuir vida ao inimigo conforme o level
		if(Principal.level == 1)
		{
			vidaInimigo = Random.Range(2, 4);			
		}
		else if(Principal.level == 2)
		{
			vidaInimigo = Random.Range(4, 6);
		}
		else if(Principal.level == 3)
		{
			vidaInimigo = Random.Range(6, 8);
		} 	 	
		else if(Principal.level == 4)
		{
			vidaInimigo = Random.Range(8, 10);
		}
		else
		{
			vidaInimigo = Random.Range(10, 15);
		}
		
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		Mover();
	}
	
	
	void Mover()
	{
		transform.Translate(Vector3.back * velocidadeFinal * Time.deltaTime);
		//destroi o inimigo quando passa do limite
	
		if(transform.position.z <= limite)
		{
			Destroy(gameObject);
		}
	
	}
	
	
	void OnCollisionEnter(Collision colisao)
	{		
		// Controla a vida do inimigo
		if(colisao.gameObject.tag == "projetil" || colisao.gameObject.tag == "Player")
		{
			// Subtrai vida do inimigo e emite parituclas de faisca como feedback
			if(colisao.gameObject.tag == "projetil")
			{
				vidaInimigo--;
			}
			else
			{
				vidaInimigo = 0;
			}
			
			
			Instantiate(faisca, transform.position, transform.rotation);
			
			// Verifica se o inimigo morreu
			if(vidaInimigo <= 0)
			{
				// Atrbuir pontos pela morte do inimigo
				Principal.pontos++;
			
				// Emite particulas de explosao e destroi o inimigo
				Instantiate(explosao, transform.position, transform.rotation);
				Destroy(gameObject);
			}
		}
		
			
		
	}
	
	
	
}
