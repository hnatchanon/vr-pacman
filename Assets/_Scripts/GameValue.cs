using UnityEngine;
using System.Collections;

public class GameValue : MonoBehaviour
{

    public Transform[] counts;

    public static int START_STATE = 0;
    public static int WIN_STATE = 1;
    public static int OVER_STATE = 2;
    public static int WAIT_STATE = 3;

    int state;
    private int point;
    private int cnt = 0;
    float feverTime = 0f;

    void Start()
    {
        state = START_STATE;
        foreach (Transform c in counts)
        {
            foreach (Transform child in c)
            {
                if (child.gameObject.activeSelf)
                    cnt++;
            }
        }
        point = 0;
    }

    void FixedUpdate()
    {
        int ctmp = 0;
        foreach (Transform c in counts)
        {
            foreach (Transform child in c)
            {
                if (child.gameObject.activeSelf)
                    ctmp++;
            }
        }
        cnt = ctmp;

        if (cnt <= 0 && state != WAIT_STATE)
        {
            state = WIN_STATE;
            feverTime = 0;
        }

        if (feverTime > 0)
        {
            feverTime -= Time.deltaTime;
        }

        if (feverTime < 0)
        {
            feverTime = 0;
        }

        //Count active items
        int tmp = 0;
        foreach (Transform c in counts)
        {
            foreach (Transform child in c)
            {
                if (child.gameObject.activeSelf)
                    tmp++;
            }
        }
        cnt = tmp;
    }

    public void AddPoint(int n)
    {
        point += n;
    }

    public int GetPoint()
    {
        return point;
    }

    public void SetFeverTime(float n)
    {
        feverTime = n;
    }

    public bool IsFever()
    {
        return feverTime > 0;
    }

    public int GetCountActiveItem()
    {
        return cnt;
    }

    public int GetState()
    {
        return state;
    }

    public void SetState(int s)
    {
        state = s;
    }
}
