public class Fire : ICommand
{
    public void Execute(Raven raven)
    {
        raven.AcornSpawner.SpawnAcorn(raven.transform.position, raven.transform.right);
    }
}