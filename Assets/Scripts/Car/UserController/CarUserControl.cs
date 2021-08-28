using UnityEngine;

[RequireComponent(typeof(Rotate))]
[RequireComponent(typeof(Move))]
public class CarUserControl : MonoBehaviour
{
    private IRotate _rotator;
    private IMove _mover;
    private WheelUpdater _wheelUpdater;
    private Drift _drift;
    private CorpusRotateter _corpusRotateter;
    private Trails _trails;

    private void Start()
    {
        _rotator = GetComponent<Rotate>();
        _mover = GetComponent<Move>();
        _wheelUpdater = GetComponentInChildren<WheelUpdater>();
        _drift = GetComponent<Drift>();
        _corpusRotateter = GetComponentInChildren<CorpusRotateter>();
        _trails = GetComponentInChildren<Trails>();
    }

    private void Update()
    {
        _wheelUpdater.UpdateWheel(_mover.Speed, _rotator.RudderAngle);
    }

    private void FixedUpdate()
    {
        _mover.MoveCar(Mathf.Clamp(Input.GetAxis("Vertical"), 0.5f, 1));

        _rotator.RotateCar(Input.GetAxis("Horizontal"), _mover.Speed, _drift.RotateOffset);

        _drift.RecalculateValues(_mover.Speed, _rotator.RudderAngle, _rotator.MaxAngle);

        _corpusRotateter.BringTheCorpus(_drift.DriftCoef);

        _trails.LineSize = _drift.DriftCoef;
    }
}
