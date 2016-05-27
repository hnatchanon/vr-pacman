using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateBlip : MonoBehaviour
{

    public GameObject[] blips;
    public GameObject[] blipColor;

    // Use this for initialization
    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < blips.Length; i++)
        {
            foreach (Transform tran in blips[i].transform)
            {
                GameObject a = Instantiate(blipColor[i]);
                a.transform.parent = transform;

                BlipScript b = a.GetComponent<BlipScript>();
                b.target = tran;

                RectTransform c = a.GetComponent<RectTransform>();
                c.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
