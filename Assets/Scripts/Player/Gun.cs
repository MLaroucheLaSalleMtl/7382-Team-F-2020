using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float speed = 0.2f;//speed of bullet
    public GameObject bullet;
    private GameObject skill3;
    public Image forskill;

    private void Start()
    {
        skill3 = GameObject.FindGameObjectWithTag("Player");
    }
    public void Fire()
    {
            GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
    }
    public void OnFire()
    {
        
            InvokeRepeating("Fire", 1, speed);
    }
    public void stopFire()
    {
            CancelInvoke("Fire");
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    InvokeRepeating("Fire", 10, speed);
        //}
    }
}
