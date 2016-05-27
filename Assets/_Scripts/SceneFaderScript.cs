using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFaderScript : MonoBehaviour
{

    public float duration = 1f;

    bool isFadeIn = true;
    Image img;
    float a;
    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
        img = gameObject.GetComponent<Image>();
        a = 1;
        img.color = new Color(0, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn && a > 0f)
        {
            a = a - (Time.deltaTime / duration);
            img.color = new Color(0, 0, 0, a);
        }
        else if (!isFadeIn && a < 1f)
        {
            a = a + (Time.deltaTime / duration);
            img.color = new Color(0, 0, 0, a);
        }
    }

    public void FadeIn()
    {
        if (isFadeIn)
            return;
        a = 1;
        img.color = new Color(0, 0, 0, a);
        isFadeIn = true;
        text.text = "";
    }

    public void FadeOut(string t)
    {
        if (!isFadeIn && t == text.text)
            return;
        a = 0;
        isFadeIn = false;
        text.text = t;
    }
}
