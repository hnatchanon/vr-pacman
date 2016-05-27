using UnityEngine;
using System.Collections;

public class GhostResetable : MonoBehaviour
{
    public void Reset()
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(true);
            GhostScript gs = t.gameObject.GetComponent<GhostScript>();
            gs.Reset();
            gs.SpeedUp();
        }
    }
}
