using UnityEngine;
using System.Collections;

public class BossWeapon : MonoBehaviour {

    [SerializeField]
    private float coolTime;
    [SerializeField]
    private float coolMax;

    [SerializeField]
    private GameObject bullet;

    void Start()
    {

    }

    void Update()
    {
        tryFire();
    }

    private void tryFire()
    {
        coolTime -= Time.deltaTime;
        if(coolTime <= 0)
        {
            fire();
            coolTime = coolMax;
        }
    }

    //弾発射
    private void fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

}
