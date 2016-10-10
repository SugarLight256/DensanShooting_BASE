using UnityEngine;
using System.Collections;

public abstract class EntityBase : MonoBehaviour {

    private int HP;
    private float speed;

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    //継承もとで生成時の初期値を変更
    protected abstract void Init();

    //移動処理
    public void Move()
    {

    }

    //倒された時の処理
    private void Die()
    {
        Destroy(this);
    }

    //ダメージを受けた時の処理
    private void Damaged()
    {

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        this.HP--;
        Damaged();
        if(HP <= 0)
        {
            Die();
        }
    }
}
