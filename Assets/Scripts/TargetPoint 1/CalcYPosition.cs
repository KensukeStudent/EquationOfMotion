using UnityEngine;

namespace TargetPosition2
{
    public class CalcYPosition
    {
        /// <summary>
        /// シミュレーションの時間
        /// </summary>
        private float simulateTime = 0;

        public float FinalTime { private set; get; }

        public float GetPositionY(Vector3 init, float endHeight, float editorSimulateTime)
        {
            float g = Physics.gravity.y;

            // 初速度viを頂点の高さendHeightから計算
            // 公式: vf^2 = vi^2 + 2as 
            // vi^2 = 2as
            // vi = √2as
            float vi = Mathf.Sqrt(-2 * g * endHeight);

            // 頂点から落ちる時間を計算 (vf = 0 なので、FinalTime = -vi / g)
            // vf = vi + at
            // t = vi/a -> 頂点までの時間
            FinalTime = -vi / g;
            simulateTime = FinalTime * Mathf.Clamp01(editorSimulateTime);

            float y = vi * simulateTime + 0.5f * Physics.gravity.y * simulateTime * simulateTime;
            return init.y + y;
        }
    }
}