using UnityEngine;
using System.Collections;

public class InteracaoClique : MonoBehaviour {

	// Pega a informacao do objeto clicado
	public GameObject pickObject;
	
	// Inicializa o ray que sera lancado na tela
	Ray ray;
	
	// Adquire a informacao do objeto que foi acertado
	RaycastHit hit;
	

	void Update () 
	{
		// Pressionar o botao esquerdo do mouse
		if (Input.GetMouseButtonDown (0)) 
		{
			// Captura a posicao xy do mouse para criar o ponto de raio
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			// Projeta o ray para o mundo e devolve colisao
			if(Physics.Raycast(ray, out hit))
			{
				// pickObject armazenou o objeto colidido e o hit armazenou a colisao
				pickObject = hit.collider.gameObject;
				
				Destroy(pickObject);
			}
		}
	}
}
