using UnityEngine;
using System.Collections;

public class TriggerChecker : MonoBehaviour
{

    bool check = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            check = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            check = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            check = false;
        }
    }

    public bool Check()
    {
        return check;
    }
}
