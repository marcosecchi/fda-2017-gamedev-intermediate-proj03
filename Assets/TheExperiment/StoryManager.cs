using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class StoryManager : MonoBehaviour {

	// L'asset (in formato JSON) generato dalla storia Ink
	[SerializeField]
	private TextAsset inkJSONAsset;

	// Il gestore della storia
	private Story _story;

	// Il container degi testie dei pulsanti
	[SerializeField]
	private Transform container;

	// Il prefab dei pulsanti
	[SerializeField]
	private Button buttonPrefab;

	// Il prefab dei testi
	[SerializeField]
	private Text textPrefab;

	void Start () {
		StartStory ();	
	}

	// Inizializza la storia e rigenera la view
	void StartStory() {
		_story = new Story (inkJSONAsset.text);
		RefreshView ();
	}

	// Rigenera la view
	void RefreshView() {

		// Rimuovere tutti gli elementi

		// Cicla sugli elementi della storia,
		// fino a trovare una opzione
		while(_story.canContinue) {
			// salva la riga di testo successiva
			string text = _story.Continue ();
			//Debug.Log (text);
			CreateContentView (text);
		}
		// Creare gli oggetti (pulsanti)
	}

	// Aggiunge una riga di testo al container,
	// instanziando il prefab
	void CreateContentView(string text) {
		Text storyText = Instantiate (textPrefab) as Text; 
		storyText.text = text;
		storyText.transform.SetParent(container);
	}
	
}
