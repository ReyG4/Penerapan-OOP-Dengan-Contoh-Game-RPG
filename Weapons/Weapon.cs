using OOP.Entites;
using OOP.Interface;
using OOP.Items;

namespace OOP.Weapons;

class Weapon(string name, int damage) : Item(name, 1), IWeapon
{
    public int Damage { get; set; } = damage;

    public virtual void Attack(Player player)
    {
        Console.WriteLine($"Kamu menyerang dengan {Name}! Damage: {Damage}");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Weapon: {Name}, Damage: {Damage}");
    }

}