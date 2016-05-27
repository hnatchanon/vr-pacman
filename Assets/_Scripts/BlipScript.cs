using UnityEngine;
using System.Collections;

public class BlipScript : MonoBehaviour {

	public Transform target;

	MinimapScript map;
	RectTransform myRectTransform;


	void Start() {
		map = GetComponentInParent<MinimapScript> ();
		myRectTransform = GetComponent<RectTransform> ();
	}

	void LateUpdate() {
		Vector2 newPosition = map.TransformPosition (target.position);

		newPosition = map.MoveInside (newPosition);

		myRectTransform.localPosition = newPosition;

		if (!target.gameObject.activeSelf) {
			gameObject.SetActive (false);
		}
	}
}
