using UnityEngine;
using Enemys;

public class GameController : MonoBehaviour
{
    private Monster Ogre;
    private Alien Xenomorph;
    private void Awake()
    {
        Debug.Log("PRIMERO SE EJECUTA AWAKE");
    }
    private void Start()
    {
        Monster Ogre = new Monster("Ogro Malvado");
        Alien Xenomorph = new Alien("Alien Xenomorfico");

        Ogre.AddSkill("Fuerza Brutal");
        Ogre.AddSkill("Piel de Pidra");
        Ogre.AddWeak("Luz Solar");
        Ogre.AddWeak("Fuego");

        Xenomorph.AddSkill("Sangre Acida");
        Xenomorph.AddSkill("Velocidad de Vertigo");
        Xenomorph.AddWeak("Fuego");

        Debug.Log("--- Info enemigos generados ---");
        Ogre.ShowSkills();
        Ogre.ShowWeaks();

        Debug.Log("");
        Xenomorph.ShowSkills();
        Xenomorph.ShowWeaks();

        Debug.Log("--- Ataque de Enemigos ---");
        Ogre.Attack();
        Xenomorph.Attack();
        Debug.Log("");

        Debug.Log("--- Mensajes de Derrota ---");
        Ogre.DefeatText();
        Xenomorph.DefeatText();
    }
}