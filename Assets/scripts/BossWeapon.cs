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
    private float rotateSpeed;

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
                //verticalShot();
                fanShot(16, 90, 20);
            }
            yield return new WaitForSeconds(coolMax);
        }
    }

    private void verticalShot(float angle)
    {
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
    }

    private void fanShot(int amount, float distRange, float mid)
    {
        for(int i=0; i<=amount; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, distRange/amount * i - distRange/2 + mid)));
        }
    }

    private void move()
    {
        time += Time.fixedDeltaTime * rotateSpeed;
        time %= 2*Mathf.PI;
        transform.localPosition = new Vector3(radius * Mathf.Cos(time + shift * Mathf.PI),radius * Mathf.Sin(time + shift * Mathf.PI), 0);
    }

}
