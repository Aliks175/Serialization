using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private List<TEstAbstruct> _anyAbilities;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            foreach (var ability in _anyAbilities)
            {
                if (ability is IAbilityTarget)
                {
                  var a= ability as IAbilityTarget;
                    a.indexTarget++;
                }

                ability.Execute();
            }
        }
    }
}
