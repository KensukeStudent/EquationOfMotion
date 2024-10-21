using UnityEngine;
using System.Collections.Generic;

namespace TargetPosition
{
    public class TargetPointCreater : MonoBehaviour
    {
        [SerializeField, Header("頂点の高さ: halfHeight"), Range(0.1f, 10)]
        private float halfHeight;

        [SerializeField]
        private Transform start;

        [SerializeField]
        private Transform end;

        private CalcYPosition calcYPosition = null;

        private CalcXPosition calcXPosition = null;

        [SerializeField]
        private GameObject prefab = null;

        private List<GameObject> objs = new();

        [SerializeField, Range(0.016f, 0.16f)]
        private float duration;

        private void Awake()
        {
            calcYPosition = new CalcYPosition();
            calcXPosition = new CalcXPosition();
        }

        private void Update()
        {
            for (int i = 0; i < objs.Count; i++)
            {
                objs[i].SetActive(false);
            }

            // y,z軸固定
            float distance = end.position.x - start.position.x;

            int count = 0;
            for (float i = 0; i <= 1; i += duration)
            {
                var y = calcYPosition.GetPositionY(start.position, halfHeight, i);
                var x = calcXPosition.GetPositionX(start.position, distance, calcYPosition.FinalTime, i);

                if (count >= objs.Count)
                {
                    objs.Add(Instantiate(prefab));
                }

                objs[count].SetActive(true);
                objs[count].transform.position = new Vector3(x, y, 0);
                count++;

                Debug.Log(count);
            }
        }
    }
}