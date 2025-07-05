using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode Tap = KeyCode.Space;
    private const KeyCode Attack = KeyCode.F;

    [SerializeField] private Raven _raven;

    private TapCommand _tapCommand = new TapCommand();
    private FireCommand _fireCommand = new FireCommand();

    private void Update()
    {
        if (Input.GetKeyDown(Tap))
        {
            _tapCommand.Execute(_raven);
        }

        if (Input.GetKeyDown(Attack))
        {
            _fireCommand.Execute(_raven);
        }
    }
}
