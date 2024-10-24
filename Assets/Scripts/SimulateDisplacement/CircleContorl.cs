using UnityEngine;

/// <summary>
/// 変位基準のシュミレート
/// 頂点座標と距離を用いた斜方投射
/// </summary>
namespace Displacement
{
    public class CircleContorl : MonoBehaviour
    {
        [SerializeField, Header("シュミレートタイム"), Range(0.0f, 1.0f)]
        private float editorSimulateTime;

        [SerializeField]
        private JumpControl jump = null;

        [SerializeField]
        private MoveControl move = null;

        [SerializeField]
        private Vector3 init;

        private float timer = 0;

        private void OnValidate()
        {
            jump.SimulateRun(init, editorSimulateTime);
            move.SimulateRun(init, jump.FinalTime, editorSimulateTime);
        }

        private void Update()
        {
            timer += timer >= 1 ? -1 : Time.deltaTime;
            jump.SimulateRun(init, timer);
            move.SimulateRun(init, jump.FinalTime, timer);
        }
    }
}