using UnityEngine;
using System.Collections;

public class Nave : MonoBehaviour {

	public float velocidade;
	public GameObject explosao;
	
	Vector3 posicaoInicial;
	bool imortalTemporario;
	
	Renderer render;
					
	void Start ()
	{	
		// Acessa as propriedades de render do objeto quando ele nasce
		render = GetComponent<Renderer>();	
						
		// Captura a posicao inicial do jogador
		posicaoInicial = transform.position;	
	}
					
		
	void Update () 
	{
		Mover();
	}
	
	// Controles da nave
	void Mover()
	{
		
		// Coletar os inputs
		float posicaoX = Input.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
		float posicaoZ = Input.GetAxisRaw("Vertical") * velocidade * Time.deltaTime;
		
		// Move a nave
		transform.Translate(posicaoX, 0.0f, posicaoZ);
				
		
	}
	
	
	void OnCollisionEnter(Collision colisao)
	{
		
		if(colisao.gameObject.tag == "Inimigo")
		{
			// Atribui imortalidade temporaria para a nave
			imortalTemporario = true;	
			
			if(imortalTemporario)
			{
				imortalTemporario = false;
				StartCoroutine(PiscarImortal());
			}
			
			
			Principal.vidas--;
			
			if(Principal.vidas < 0)
			{
				Application.LoadLevel("Start");
			}
			Instantiate(explosao, transform.position, transform.rotation);
			transform.position = new Vector3(posicaoInicial.x, posicaoInicial.y, posicaoInicial.z);	
		}
		
		
			
	}
	
	// Mantem a nave imortal por 3 segundos
	IEnumerator PiscarImortal()
	{	
		render.enabled = false;
		yield return new WaitForSeconds(0.3f);
		render.enabled = true;
		yield return new WaitForSeconds(0.3f);
		render.enabled = false;
		yield return new WaitForSeconds(0.3f);
		render.enabled = true;		
		yield return new WaitForSeconds(0.3f);
		render.enabled = false;		
		yield return new WaitForSeconds(0.3f);
		render.enabled = true;
		yield return new WaitForSeconds(0.3f);
		render.enabled = false;		
		yield return new WaitForSeconds(0.3f);
		render.enabled = true;								
	}
	
	
}
