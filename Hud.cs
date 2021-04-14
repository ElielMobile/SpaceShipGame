using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Hud : MonoBehaviour {

	public Text hudPontos;
	public Text hudVidas;
	public Text hudLevel;	
	
	// Update is called once per frame
	void Update () 
	{
		AtualizarHud();		
	}
	
	
	void AtualizarHud()
	{
		hudPontos.text = Principal.pontos.ToString();
		hudVidas.text = Principal.vidas.ToString();
		hudLevel.text = Principal.level.ToString();
	}
}
