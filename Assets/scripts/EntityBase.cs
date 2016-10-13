using UnityEngine;
using System.Collections;
using DG.Tweening;

public abstract class EntityBase : MonoBehaviour {

    protected int HP;
    protected float speed;

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
    protected virtual void Move()
    {

    }

    //倒された時の処理
    protected virtual void Die()
    {
        Destroy(this);
    }

    //ダメージを受けた時の処理
    protected virtual void Damaged()
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
