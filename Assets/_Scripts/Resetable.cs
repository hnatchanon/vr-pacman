using UnityEngine;
using System.Collections;

public class Resetable : MonoBehaviour
{

    public void Reset()
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(true);
        }
    }
}
