using UnityEngine;

namespace TargetPosition2
{
    public class CalcXPosition
    {
        /// <summary>
        /// シュミレートタイム
        /// </summary>
        private float simulateTime;

        public float GetPositionX(Vector3 init, float distance, float endTime, float editorSimulateTime)
        {
            // s = vi*t
            // vi = s/t
            simulateTime = endTime * editorSimulateTime;

            float vi = distance / endTime;
            return init.x + vi * simulateTime;
        }
    }
}