using UnityEngine;

namespace TargetPosition5
{
    /// <summary>
    /// 点から点への斜方投射
    /// <para>頂点は決められない</para>
    /// </summary>
    public class MovePointer : MonoBehaviour
    {
        /// <summary>
        /// アニメーションの長さ
        /// </summary>
        private float t = 0;

        /// <summary>
        /// アニメーション速度
        /// </summary>
        [Min(0.01f)]
        private float speed = 1;

        /// <summary>
        /// 放物線の移動を反転する
        /// </summary>
        private bool isFlip = false;

        private float timer = 0;

        public bool IsComplete => timer >= t;

        /// <param name="duration">アニメーションの長さ</param>
        /// <param name="speed">アニメーション速度</param>
        /// <param name="isFlip">反転有り</param>
        public void Setting(float duration, float speed, bool isFlip)
        {
            this.t = duration;
            this.speed = speed;
            this.isFlip = isFlip;
            timer = 0;

            gameObject.SetActive(true);
        }

        public void OnUpdate(Transform start, Transform end)
        {
            timer += Time.deltaTime * speed;
            float gravity = isFlip ? -Physics2D.gravity.y : Physics2D.gravity.y;

            var startPos = start.position;
            var endPos = end.position;
            var diffY = (endPos - startPos).y;
            var vn = (diffY - gravity * 0.5f * t * t) / t;

            // 水平方向の速度を計算
            var distanceX = endPos.x - startPos.x;
            // 水平方向の速度
            var v_x = distanceX / t;

            var x = startPos.x + v_x * timer;
            var y = startPos.y + vn * timer + 0.5f * gravity * timer * timer;

            transform.position = new Vector3(x, y, 0);

            if (IsComplete)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
