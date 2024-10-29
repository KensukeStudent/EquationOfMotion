using UnityEngine;

namespace TargetPosition4
{
    /// <summary>
    /// 点から点への斜方投射
    /// <para>頂点は決められない</para>
    /// </summary>
    public class TargetPointCreater : MonoBehaviour
    {
        [SerializeField, Header("指定座標の放物線を通る時間")]
        private float targetTime = 0;

        [SerializeField, Min(0.01f)]
        private float speed = 1;

        [SerializeField]
        private Transform start;

        [SerializeField]
        private Transform end;

        [SerializeField]
        private GameObject moveObj = null;

        private float timer = 0;

        private void Update()
        {
            timer += Time.deltaTime * speed;

            var startPos = start.position;
            var endPos = end.position;
            var diffY = (endPos - startPos).y;
            var vn = (diffY - Physics2D.gravity.y * 0.5f * targetTime * targetTime) / targetTime;

            // 水平方向の速度を計算
            var distanceX = endPos.x - startPos.x;
            // 水平方向の速度
            var v_x = distanceX / targetTime;

            var x = startPos.x + v_x * timer;
            var y = startPos.y + vn * timer + 0.5f * Physics2D.gravity.y * timer * timer;

            moveObj.transform.position = new Vector3(x, y, 0);

            float x0 = 16 * 10 / 9;
            var camPos = Camera.main.transform.position.x + x0 / 2;
            if (moveObj.transform.position.x > camPos)
            {
                timer = 0;
            }
        }
    }
}
