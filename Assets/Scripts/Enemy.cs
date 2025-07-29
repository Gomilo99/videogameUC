using UnityEngine;
using System.Collections.Generic;

namespace Enemys
{
    //Clase padre Enemigo
    public class Enemy
    {
        public string Name;
        protected List<string> _skills;
        protected List<string> _weaknesses;

        public float attackPoints;
        public int lifePoints;

        public Enemy(string name)
        {
            Name = name;
            _skills = new List<string>();
            _weaknesses = new List<string>();
        }
        public virtual void Attack(float damage) {
            Debug.Log("Ataca!!");
        }
        public virtual void AddSkill(string skill) {
            _skills.Add(skill);
        }
        public virtual void AddWeak(string weak) {
            _weaknesses.Add(weak);
        }
        public virtual void DefeatText() {
            Debug.Log("Mi destino ha llego a su final...");
        }
        public void ShowSkills() {
            string skillsList = "Habilidades: ";
            if (_skills.Count == 0)
            {
                Debug.Log(" Ninguna.");
            }
            else
            {
                foreach (var skillItem in _skills)
                {
                    skillsList += skillItem + ", ";
                }
                Debug.Log(skillsList);
            }
            
        }
    }

    //Clase derivada Monster, heredada de Enemy
    public class Monster : Enemy
    {
        // Constructor de la clase Monster
        public Monster(string name) : base(name) { }
        public override void DefeatText()
        {
            Debug.Log($"{Name} ROOOOOAAAAR *se muere*");
        }
        public override void Attack(float damage)
    {
        Debug.Log($"{Name} ruge y ataca con sus garras afiladas!");
    }

    }
}