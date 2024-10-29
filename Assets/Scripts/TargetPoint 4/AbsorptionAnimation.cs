using System.Collections.Generic;
using UnityEngine;

namespace TargetPosition5
{
    public class AbsorptionAnimation : MonoBehaviour
    {
        [SerializeField, Range(0, 100)]
        private int circleCount = 0;

        [SerializeField]
        private MovePointer prefab = null;

        [SerializeField]
        private Transform start;

        [SerializeField]
        private Transform end;

        private List<MovePointer> list = new();

        [SerializeField]
        private AnimationTable[] tables = null;

        private void Awake()
        {
            CreatePoint();
        }

        private void CreatePoint()
        {
            for (int i = 0; i < circleCount; i++)
            {
                var go = Instantiate(prefab);
                list.Add(go);
            }
        }

        private void Update()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].IsComplete)
                {
                    list[i].OnUpdate(start, end);
                }
                else
                {
                    var table = tables[Random.Range(0, tables.Length)];
                    float duration = table.duration;
                    float speed = Random.Range(table.speedMin, table.speedMax + 0.1f);
                    bool isFlip = Random.Range(0, 2) == 0;
                    list[i].Setting(duration, speed, isFlip);
                }
            }
        }
    }
}