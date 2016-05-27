using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RedFilterScript : MonoBehaviour {

	public GameValue gameValue;
	public float speed = 1f;
	public float max = 0.3f;

	Image img;
	float value = 0;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gameValue.IsFever () && value < 1) {
			value += Time.deltaTime * speed;
			if (value > 1f)
				value = 1f;
		} else if(!gameValue.IsFever() && value > 0) {
			value -= Time.deltaTime * speed;
			if (value < 0)
				value = 0f;
		}

		img.color = new Color (img.color.r, img.color.g, img.color.b, value * max);
	}
}
