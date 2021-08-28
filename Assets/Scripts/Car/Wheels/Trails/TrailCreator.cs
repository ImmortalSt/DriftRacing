using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCreator : MonoBehaviour
{   
    [SerializeField] private MeshEditor _meshEditor;
    [SerializeField] private LayerMask _layerMask;

    private static Trails _trails;
    private float _lineSize;
    private bool isDrift = false;

    private void Start()
    {
        _trails = GetComponentInParent<Trails>();
    }


    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.up * -1, 50, _layerMask))
        {
            _lineSize = _trails.LineSize;
            if (Mathf.Abs(_lineSize) >= 0.01f)
            {
                if (isDrift == false)
                    _meshEditor.AddDotAndConnectLastTriagle(transform.position + transform.forward * _lineSize);

                _meshEditor.AddDotAndConnectLastTriagle(transform.position + transform.forward * _lineSize);
                _meshEditor.AddDotAndConnectLastTriagle(transform.position - transform.forward * _lineSize);
                isDrift = true;
            }
            else if (isDrift == true)
            {
                _meshEditor.AddDotAndConnectLastTriagle(transform.position);
                _meshEditor.AddDotAndConnectLastTriagle(transform.position);
                isDrift = false;
            }
        }
    }
}
