using UnityEngine;

namespace Displacement
{
    /// <summary>
    /// 運動方程式を用いた移動
    /// </summary>
    public class MoveControl : MonoBehaviour
    {
        [SerializeField, Header("移動地点"), Range(0.1f, 10)]
        private float distance;

        /// <summary>
        /// シュミレートタイム
        /// </summary>
        private float simulateTime;

        public void SimulateRun(Vector3 init, float endTime, float editorSimulateTime)
        {
            // s = vi*t
            // vi = s/t
            simulateTime = endTime * editorSimulateTime;

            float vi = distance / endTime;
            float x = vi * simulateTime;

            var pos = transform.position;
            pos.x = init.x + x;
            transform.position = pos;
        }
    }
}