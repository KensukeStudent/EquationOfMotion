using UnityEngine;
using System.Collections.Generic;

namespace TargetPosition2
{
    public class TargetPointCreater : MonoBehaviour
    {
        [SerializeField]
        private float t = 0;

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
            var diffY = (end.position - startPos).y; // 始点と終点のy成分の差分
            var vn = (diffY - Physics2D.gravity.y * 0.5f * t * t) / t; // 鉛直方向の初速度vn
            float endT = t;

            // 放物運動
            for (var t = 0f; t < endT; t += pointDuration)
            {
                if (count >= objs.Count)
                {
                    objs.Add(Instantiate(prefab));
                }

                var p = Vector3.Lerp(startPos, end.position, t / endT);   //水平方向の座標を求める (x,z座標)
                p.y = startPos.y + vn * t + 0.5f * Physics2D.gravity.y * t * t; // 鉛直方向の座標 y

                objs[count].SetActive(true);
                objs[count].transform.position = p;
                count++;
            }
        }
    }
}