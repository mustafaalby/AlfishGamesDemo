using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceArea : MonoBehaviour
{
    List<GameObject> forcedObjects = new List<GameObject>();
    
    private void OnTriggerEnter(Collider other)
    {
        forcedObjects.Add(other.gameObject);
        
    }
    private void OnTriggerExit(Collider other)
    {
        forcedObjects.Remove(other.gameObject);
    }
    public void ApplyForce()
    {
        for (int i = 0; i < forcedObjects.Count; i++)
        {
            forcedObjects[i].GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1) * 300);
        }
        forcedObjects.Clear();
    }
}
/*
 Force Area, kontrol ettiğimiz nesne içerisindeki topladığımız nesnelerin, checkpoint noktasına düşmedikleri için
 bu nesnelere Force uyguladığımız alandır. Uygulanan Force ile nesneleri checkpoint noktasına atarak puanları alıyoruz.
     */