// -------------------------------------------------------------------
// Auther: nagase
// ゲーム数学参考書: p294
// -------------------------------------------------------------------

using UnityEngine;

namespace Displacement
{
    /// <summary>
    /// 頂点を基準にした上下運動のシミュレーション
    /// <para>シュミレート専用: 運動方程式</para>
    /// </summary>
    public class JumpControl : MonoBehaviour
    {
        [SerializeField, Header("頂点の高さ: halfHeight"), Range(0.1f, 10)]
        private float halfHeight;

        /// <summary>
        /// シミュレーションの時間
        /// </summary>
        private float simulateTime = 0;

        public float FinalTime { private set; get; }

        public void SimulateRun(Vector3 init, float editorSimulateTime)
        {
            float g = Physics.gravity.y;

            // 初速度viを頂点の高さhalfHeightから計算
            // 公式: vf^2 = vi^2 + 2as 
            // vi^2 = 2as
            // vi = √2as
            float vi = Mathf.Sqrt(-2 * g * halfHeight);

            // 頂点から落ちる時間を計算 (vf = 0 なので、FinalTime = -vi / g)
            // vf = vi + at
            // t = vi/a -> 頂点までの時間
            // t = 2 * vi/aで頂点までの時間*2 -> 頂点から底点までの時間
            FinalTime = 2 * (-vi / g);
            simulateTime = FinalTime * Mathf.Clamp01(editorSimulateTime);

            Debug.Log($"finalTime: {FinalTime}/ simulateTime: {simulateTime}");
            SetPosition(init, vi);
        }

        private float GetPositionY(float vi)
        {
            // 高さの計算 (s = vi * t + 0.5 * g * t^2)
            return vi * simulateTime + 0.5f * Physics.gravity.y * simulateTime * simulateTime;
        }

        private void SetPosition(Vector3 init, float vi)
        {
            var pos = transform.position;
            pos.y = init.y + GetPositionY(vi); // 初期y位置に変位を加算
            transform.position = pos;
        }
    }
}