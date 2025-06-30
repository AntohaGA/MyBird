using UnityEngine;

public class Fire : ICommand
{
    public void Execute(Raven raven)
    {
        Debug.Log("Fire!");
        // Здесь логика выстрела
    }
}