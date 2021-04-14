using UnityEngine;
using System.Collections;

public class CriarInimigos : MonoBehaviour {
	public GameObject inimigo;
	public float limeteEsquerdo, limiteDireito, limiteFrontal, limiteTraseiro;
	float TempoGerarInimigos;

	// Use this for initialization
	void Start () 
	{
	DefinirTempo();
	 StartCoroutine(GerarInimigos());
	}
	
	// Update is called once per frame
	void Update () 
	{	
		DefinirTempo();
	}
		
	void DefinirTempo()
	{
		if(Principal.level == 1)
		{
			// 5seg quando começar a contar o tempo
			TempoGerarInimigos=3.0f;
		}
		else if(Principal.level == 2)
		{
			TempoGerarInimigos=13.0f;
		}else if(Principal.level == 3)
		{
			TempoGerarInimigos=10.0f;
		}else if(Principal.level == 4)
		{
			TempoGerarInimigos=8.0f;
		}else if(Principal.level == 5)
		{
			TempoGerarInimigos=5.0f;
		}
	
	}
	IEnumerator GerarInimigos()
	
	{	//sorteia posicao em X
		int posicaoX = Random.Range((int)limeteEsquerdo,(int)limiteDireito);
		int posicaoZ = Random.Range((int)limiteFrontal,(int)limiteTraseiro);
		
		//monta cordenada final
		Vector3 posicaoFinal = new Vector3((float)posicaoX,0.0f, (float)posicaoZ);
		
		//instanciando inimigo na posicao sorteada
		Instantiate(inimigo, posicaoFinal, transform.rotation);
		
		
		yield return new WaitForSeconds(TempoGerarInimigos);
		StartCoroutine(GerarInimigos());
	}
			

	
	
}

