using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private Manage manage;
    private void Awake()
    {
        manage = GameObject.Find("Manager").GetComponent<Manage>();
    }
    /*
     FinishLine daki trigger player nesnesi ile tetiklendiğinde, manage scriptinde ki LevelCompleted fonksiyonu çalıştırılır.
         */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            manage.LevelCompleted();
        }
    }
}
