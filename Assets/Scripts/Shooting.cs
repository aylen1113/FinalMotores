using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firstPersonCamera;
    public Transform firePoint;  
    public float range = 200;
    public LayerMask layers;
    public GameObject projectile;

    private void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = new Ray(firstPersonCamera.position, firstPersonCamera.forward);

            if (Physics.Raycast(ray, out hit, range, layers))
            {
                GameObject proj;
                proj = Instantiate(projectile, firePoint.position, firePoint.rotation);  // firePoint 

                Rigidbody rb = proj.GetComponent<Rigidbody>();
                rb.AddForce(firePoint.forward * 30, ForceMode.Impulse);  // firePoint

                Destroy(proj, 5);

                Debug.Log("Shot");
            }
        }
    }
}
