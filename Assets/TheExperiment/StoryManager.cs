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

	[SerializeField]
	private Image sherlockPortrait;

	[SerializeField]
	private Image johnPortrait;

	[SerializeField]
	private Color sherlockTextColor;

	[SerializeField]
	private Color johnTextColor;

	[SerializeField]
	private Color greyedOutPortaitColor;

	void Start () {
		StartStory ();	
	}

	// Inizializza la storia e rigenera la view
	void StartStory() {
		_story = new Story (inkJSONAsset.text);
		StartCoroutine (RefreshView());
	}

	// Rigenera la view
	IEnumerator RefreshView() {

		RemoveChildren ();

		// Cicla sugli elementi della storia,
		// fino a trovare una opzione
		while (_story.canContinue) {
			string text = _story.Continue ().Trim();
			yield return new WaitForSeconds(.3f);
			CreateContentView(text);
		}

		if(_story.currentChoices.Count > 0) {
			for (int i = 0; i < _story.currentChoices.Count; i++) {
				Choice choice = _story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		} else {
			Button choice = CreateChoiceView("Ricomincia");
			choice.onClick.AddListener(delegate{
				StartStory();
			});
		}
	}

	void OnClickChoiceButton (Choice choice) {
		_story.ChooseChoiceIndex (choice.index);
		StartCoroutine (RefreshView());
	}

	Sprite GetPortrait(List<string> list, string character) {
		foreach (string tag in list) {
			Sprite s = Resources.Load<Sprite> (character + "/" + tag);
			if (s != null)
				return s;
		}
		return null;
	}

	Button CreateChoiceView (string text) {
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (container, false);

		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		return choice;
	}

	// Aggiunge una riga di testo al container,
	// instanziando il prefab
	void CreateContentView (string text) {
		johnPortrait.color = greyedOutPortaitColor;
		sherlockPortrait.color = greyedOutPortaitColor;
		Text storyText = Instantiate (textPrefab) as Text;
		storyText.text = text;
		if (text.StartsWith ("S:")) {
			storyText.color = sherlockTextColor;
			Sprite p = GetPortrait (_story.currentTags, "holmes");
			if (p != null)
				sherlockPortrait.sprite = p;
			sherlockPortrait.color = Color.white;

		}
		if (text.StartsWith ("J:")) {
			storyText.color = johnTextColor;
			Sprite p = GetPortrait (_story.currentTags, "watson");
			if (p != null)
				johnPortrait.sprite = p;
			johnPortrait.color = Color.white;

		}
		storyText.transform.SetParent (container, false);
	}

	void RemoveChildren () {
		int childCount = container.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			GameObject.Destroy (container.GetChild (i).gameObject);
		}
	}
	
}
