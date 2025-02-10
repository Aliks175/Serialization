using UnityEngine;

public class SayAbility : TEstAbstruct
{
    [SerializeField] private string _saytext;
    public override void Execute()
    {
        Debug.Log(_saytext);
    }
}
