using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshTest
{
    public class MeshRaycastPointer : MonoBehaviour
    {
        public static float _lineSize = 0;

        [SerializeField] private MeshEditor _meshEditor;

        private void FixedUpdate()
        {
            if (Mathf.Abs(_lineSize) >= 0.01f)
            {
                _meshEditor.AddDotAndConnectLastTriagle(transform.position + transform.right * _lineSize);
                _meshEditor.AddDotAndConnectLastTriagle(transform.position - transform.right * _lineSize);
            }
        }

        public void HitMesh()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out var hit))
            {
                if (hit.transform.TryGetComponent<Target>(out var target))
                {
                    _meshEditor.AddDotAndConnectLastTriagle(hit.point + new Vector3(0, 0.01f, 0));
                }

            }
        }
    }
}
