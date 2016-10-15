using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class BossBase : EntityBase
{
    //座標を表す列挙体
    enum movePos {
        MID,
        UP,
        DOWN,
        UPPER_RIGHT,
        UPPER_LEFT,
    };

    //列挙対に対応する座標一覧
    [SerializeField]
    private Vector3[] pos = new Vector3[]{
        new Vector3(0,0),
        new Vector3(0,5) ,
        new Vector3(0,-3),
        new Vector3(7,5),
        new Vector3(-7,5)
    };

    //道順リスト
    private List<Vector3[]> pathList = new List<Vector3[]>();

    [SerializeField]
    private int pathIndex = 0;//どの道のりを選んでいるか
    private int pathCount = 0;//どの中継地点にいるか
    private float timer = 0;//タイマー

    [SerializeField]
    private float timerMax = 2.0f;
    [SerializeField]
    private float timerMin = 3.0f;
    [SerializeField]
    private float moveTime = 1.5f;
    
    /// ここまで変数宣言/////////////////////////////////////////////////////////

    //生成処理
    protected override void Init()
    {
        HP = 100;
        speed = 1;
        pathList.Add(new Vector3[] {
            pos[(int)movePos.UP],
            pos[(int)movePos.UPPER_RIGHT],
            pos[(int)movePos.UP],
            pos[(int)movePos.UPPER_LEFT]
        });
    }

    //移動処理
    protected override void Move()
    {
        if (!DOTween.IsTweening(transform))
        {
            if (timer <= 0)
            {
                if (pathIndex == -1)
                {
                    randomMove();
                }
                else if(pathIndex == -2)
                {
                    //dont move
                }
                else
                {
                    pathMove();
                }
                timer = Random.Range(timerMin, timerMax);//その場で待機
            }
        }
        timer -= Time.deltaTime;
    }

    //ランダム移動
    private void randomMove()
    {
        transform.DOMove(pos[(int)Random.Range(0, 5)], moveTime);//0~4ランダムな指定座標に移動
    }

    //一定の道に沿った移動処理
    private void pathMove() { pathMove(this.pathIndex); }
    private void pathMove(int Index)
    {
        pathCount %= pathList[Index].Length;//コレクションの範囲を超えないようにする
        transform.DOMove(pathList[Index][pathCount], moveTime);
        pathCount++;
    }

    //MovePathが変わったときの処理
    private void changeMovePath(int newPath)
    {
        pathIndex = newPath;
        pathCount = 0;
    }
}
