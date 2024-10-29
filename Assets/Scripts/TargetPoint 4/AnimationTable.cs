using UnityEngine;

namespace TargetPosition5
{
    [CreateAssetMenu(fileName = "AnimationTable", menuName = "ScriptableObjects/AnimationTable")]
    public class AnimationTable : ScriptableObject
    {
        /// <summary>
        /// アニメーションの長さ
        /// </summary>
        public float duration;

        /// <summary>
        /// アニメーションの速度最小
        /// </summary>
        public float speedMin;

        /// <summary>
        /// アニメーションの速度最大
        /// </summary>
        public float speedMax;
    }
}