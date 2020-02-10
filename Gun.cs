using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float speed = 0.2f;//speed of bullet
    public GameObject bullet;

    public void Fire()
    {
        GameObject.Instantiate(bullet, transform.position, Quaternion.identity);

    }
    public void OnFire()
    {
        InvokeRepeating("Fire", 1, speed);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        OnFire();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
