using UnityEngine;

namespace TargetPosition
{
    public class CalcYPosition
    {
        /// <summary>
        /// シミュレーションの時間
        /// </summary>
        private float simulateTime = 0;

        public float FinalTime { private set; get; }

        public float GetPositionY(Vector3 init, float halfHeight, float editorSimulateTime)
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

            float y = vi * simulateTime + 0.5f * Physics.gravity.y * simulateTime * simulateTime;
            return init.y + y;
        }
    }
}