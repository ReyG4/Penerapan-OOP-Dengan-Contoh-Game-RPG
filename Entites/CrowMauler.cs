namespace OOP.Entities;

class CrowMauler : Enemy
{
    public CrowMauler() : base("Crow Mauler", 70, 10) { }

    public override void InfoEnemy()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"HP: {Hp}");
        Console.WriteLine($"Damage: {Damage}");
        Console.WriteLine("Menyerang dua kali per ronde, dan ketika kamu tidak memiliki senjata memberikan damage double");
    }

    public void SpesialAbility()
    {
        if (Hp > 30)
        {
            Random rnd = new();
            int chanceSteal = rnd.Next(1, 101);
            if (chanceSteal <= 20)
            {
                Console.WriteLine($"{Name} berhasil mencuri item dari mu!");
            }
        }
    }

    public int Attack(Player player)
    {
        if (Damage < 0) return 0;
        if (player.EquippedWeapon != null)
        {
            Console.WriteLine($"{Name} menyerang dengan paruhnya! memberikan {Damage} damage!");
            return Damage;
        }
        else
        {
            Console.WriteLine($"{Name} menyerang dengan paruh dan cakarnya! memberikan damage ganda sebesar {Damage * 2} damage!");
            return Damage * 2;
        }
    }
}