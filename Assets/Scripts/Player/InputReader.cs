using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode Tap = KeyCode.Space;
    private const KeyCode Attack = KeyCode.F;

    [SerializeField] private Raven _raven;

    private Tap _tap = new Tap();
    private Fire _fire = new Fire();

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
