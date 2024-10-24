using UnityEngine;
using System.Collections.Generic;

namespace TargetPosition3
{
    public class TargetPointCreater : MonoBehaviour
    {
        [SerializeField]
        private float t = 0;

        [SerializeField]
        private float addT = 0;

        [SerializeField]
        private Transform start;

        [SerializeField]
        private Transform end;

        [SerializeField]
        private GameObject prefab = null;

        private readonly List<GameObject> objs = new();

        [SerializeField, Range(0.016f, 0.16f)]
        private float pointDuration;

        private void Update()
        {
            for (int i = 0; i < objs.Count; i++)
            {
                objs[i].SetActive(false);
            }

            int count = 0;

            var startPos = start.position; // 初期位置
            var endPos = end.position; // 終点
            var diffY = (endPos - startPos).y; // 始点と終点のy成分の差分
            var vn = (diffY - Physics2D.gravity.y * 0.5f * t * t) / t; // 鉛直方向の初速度vn

            // 水平方向の速度を計算
            var distanceX = endPos.x - startPos.x;
            var v_x = distanceX / t; // 水平方向の速度

            float endT = t;

            // 放物運動
            for (var time = 0f; time < endT + addT; time += pointDuration) // endTを越えた時間を含める
            {
                if (count >= objs.Count)
                {
                    objs.Add(Instantiate(prefab));
                }

                // X座標を運動方程式から計算
                var xPos = startPos.x + v_x * time; // X方向の座標
                var p = new Vector3(xPos, 0, 0); // 新しいVector3を作成 (y成分は後で設定)

                // Y座標の計算
                p.y = startPos.y + vn * time + 0.5f * Physics2D.gravity.y * time * time; // 鉛直方向の座標

                // // 目的地以降の計算
                // if (time >= endT)
                // {
                //     // 目的地を越えた後のy座標
                //     p.y = Mathf.Max(p.y, endPos.y); // 終点より下にはならない
                // }

                objs[count].SetActive(true);
                objs[count].transform.position = p;
                count++;
            }
        }
    }
}
