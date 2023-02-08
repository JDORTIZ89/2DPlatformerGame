using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atooi.AI
{
    public class AIPlayerDetector : MonoBehaviour
    {
        [field: SerializeField]
        public bool PlayerDetected { get; private set; }
        public Vector2 DirectionToTarget => target.transform.position - detectorOrigin.position;
        private GameObject target;
        [SerializeField]
        private Transform detectorOrigin;
        public Vector2 detectorSize = Vector2.one;
        public Vector2 detectorOriginOffset = Vector2.zero;

        public float detectionDelay = 0.3f;

        public LayerMask detectorLayerMask;

        [Header("Gizmo Paramters")]
        public Color gizmoIdleColor = Color.green;
        public Color gizmoDetectedColor = Color.red;
        public bool showGizmos = true;


        public GameObject Target
        {
            get { return target; }
            set { target = value;
                PlayerDetected = target != null;
            }
        }


        private void Start()
        {
            StartCoroutine(DetectionCoroutine());
        }

        IEnumerator DetectionCoroutine()
        {
            yield return new WaitForSeconds(detectionDelay);
            Collider2D collider = Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayerMask);
            if(collider !=null)
            {
                Target = collider.gameObject;
            }
            else
            {
                Target = null;
            }
            StartCoroutine(DetectionCoroutine());
        }

        private void OnDrawGizmos()
        {
            if(showGizmos && detectorOrigin !=null)
            {
                Gizmos.color = gizmoIdleColor;
                if (PlayerDetected)
                    Gizmos.color = gizmoDetectedColor;
                Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
            }
        }

    }
}