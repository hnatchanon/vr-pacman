using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointTextScript : MonoBehaviour {

	public GameValue gameValue;

	Text txt;
	void Start () {
		txt = GetComponent<Text>();
	}

	void Update () {
		txt.text = "Point: " + gameValue.GetPoint ();;
	}
}
