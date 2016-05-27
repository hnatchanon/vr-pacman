
using UnityEngine;
using System.Collections;

public class MinimapScript : MonoBehaviour {

	public Transform target;
	public float zoomLevel = 10f;
	public float radius = 10f;

	Vector2 XRotation;
	Vector2 YRotation;

	void LateUpdate() {
		XRotation = new Vector2 (target.right.x, -target.right.z);
		YRotation = new Vector2 (-target.forward.x, target.forward.z);
	}

	public Vector2 TransformPosition(Vector3 position) {
		Vector3 offset = position - target.position;
		Vector2 newPosition = offset.x * XRotation;
		newPosition += offset.z * YRotation;

		newPosition *= zoomLevel;

		return newPosition;
	}

	public Vector2 MoveInside(Vector2 point) {

		Vector2 center = new Vector2(target.position.x, target.position.z);

		float d = Vector2.Distance (center, point);

		float m = point.magnitude;
		Vector2 tmpPoint = point * radius;
		tmpPoint /= m;

		float tmpD = Vector2.Distance (center, tmpPoint);

		if (tmpD < d)
			point = tmpPoint;

		return point;
	}
}
