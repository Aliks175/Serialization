using UnityEngine;

public class MoveAbility : TEstAbstruct
{
    [SerializeField] private Vector3 m_Position;
    private Transform m_Parent;

    private void Start()
    {
        m_Parent = gameObject.transform;
    }

    public override void Execute()
    {
        m_Parent.position = m_Parent.position + m_Position;
    }
}
