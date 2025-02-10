using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportedAbility : TEstAbstruct, IAbilityTarget
{
    [SerializeField] private float _timeWait;
    [SerializeField]private List<Transform> _targetss;

    public List<Transform> Targets { get { return _targetss; } set { _targetss = value; } }

    public int indexTarget
    {
        get { return index; }

        set
        {
            if (value < Targets.Count)
            {
                index = value;
            }
            else
            {
                index = 0;
            }
        }
    }
    private int index;

    private bool _isWait = false;

    public override void Execute()
    {
        if (Targets == null) { return; }
        if (!_isWait)
        {
            _isWait = true;
            StartCoroutine(WaitTeleportable());
        }
    }

    private IEnumerator WaitTeleportable()
    {
        yield return new WaitForSeconds(_timeWait);
        transform.position = Targets[indexTarget].position;
        _isWait = false;
    }
}
