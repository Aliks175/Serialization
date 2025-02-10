using System.Collections.Generic;
using UnityEngine;

public interface IAbilityTarget : IAbility
{
    public List<Transform> Targets { get; set; }

    public int indexTarget { get; set; }
}
