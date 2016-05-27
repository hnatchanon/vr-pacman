using UnityEngine;
using System.Collections;

public class GhostScript : MonoBehaviour
{
    public GameValue gameValue;
    public Vector2 startPoint;
    public TriggerChecker left;
    public TriggerChecker right;
    public TriggerChecker front;
    public Color color;
    public Color fearColor;
    public float speed = 1f;

    float sleep = 0f;
    Renderer rend;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(startPoint.x, 1.5f, startPoint.y);
        rend = GetComponent<Renderer>();
        rend.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameValue.IsFever())
        {
            rend.material.color = fearColor;
        }
        else if (rend.material.color != color)
        {
            rend.material.color = color;
        }
        if (sleep <= 0)
        {
            float x = transform.position.x;
            float z = transform.position.z;
            if (x % 4 <= 0.05f && z % 4 <= 0.05f)
            {
                int[] angle = { -90, 0, 90 };

                if (left.Check())
                {
                    angle[0] = -1;
                }
                if (front.Check())
                {
                    angle[1] = -1;
                }
                if (right.Check())
                {
                    angle[2] = -1;
                }

                int index = Random.Range(0, 3);
                while (angle[index] == -1)
                {
                    index = Random.Range(0, 3);
                }

                transform.Rotate(new Vector3(0, angle[index], 0));
                if (angle[index] != 90)
                {
                    transform.position = new Vector3(Mathf.Round(x), transform.position.y, Mathf.Round(z));
                }

                sleep = 1f;
            }
        }
        else
        {
            sleep -= Time.deltaTime;
        }

        this.transform.position += this.transform.forward * Time.deltaTime * speed;
    }

    public void WaitToRespawn()
    {
        StartCoroutine(Respawn());
    }

    public void Reset()
    {
        transform.position = new Vector3(startPoint.x, 1.5f, startPoint.y);
    }

    public void SpeedUp()
    {
        speed *= 1.5f;
    }

    IEnumerator Respawn()
    {
        float tmp = speed;
        speed = 0;
        transform.position = new Vector3(20f, -1.5f, 8f);
        yield return new WaitForSeconds(20);
        speed = tmp;
        transform.position = new Vector3(20f, 1.5f, 8f);
    }
}
