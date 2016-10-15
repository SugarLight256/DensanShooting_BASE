using UnityEngine;
using System.Collections;

public class BossWeapon : MonoBehaviour {

    [SerializeField]
    private float coolTime;
    [SerializeField]
    private float coolMax;
    [SerializeField]
    private float shift;
    [SerializeField]
    private float radius = 0.5f;

    [SerializeField]
    private bool isActive = true;

    [SerializeField]
    private GameObject bullet;

    private float time=0;

    void Start()
    {
        StartCoroutine(fire());
    }

    void FixedUpdate()
    {
        move();
    }

    //一定間隔で弾を発射するコルーチン
    private IEnumerator fire()
    {
        while (true)
        {
            if (isActive)
            {
                Instantiate(bullet, transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(coolMax);
        }
    }

    private void move()
    {
        time += (Time.fixedDeltaTime);
        time %= 2*Mathf.PI;
        transform.localPosition = new Vector3(radius * Mathf.Cos(time + shift * Mathf.PI),radius * Mathf.Sin(time + shift * Mathf.PI), 0);
    }

}
