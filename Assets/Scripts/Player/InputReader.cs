using UnityEngine;

[RequireComponent(typeof(Raven))]
public class InputReader : MonoBehaviour
{
    private Raven _raven;

    private const KeyCode Tap = KeyCode.Space;
    private const KeyCode Attack = KeyCode.F;

    private ICommand _tap = new Tap();
    private ICommand _fire = new Fire();

    private void Awake()
    {
        _raven = GetComponent<Raven>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Tap))
        {
            _tap.Execute(_raven);
        }

        if (Input.GetKeyDown(Attack))
        {
            _fire.Execute(_raven);
        }
    }
}
