using UnityEngine;
using System.Collections;

public class ForwardScript : MonoBehaviour {

	public Transform head;

	void Update () {
		Vector3 newForward = new Vector3 (head.forward.x, 0, head.forward.z);

		float d = newForward.x * newForward.x + newForward.z * newForward.z;
		d = Mathf.Sqrt (d);
		newForward /= d;

		transform.forward = newForward;

	}
}
