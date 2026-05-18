namespace OOP.Entites;

class CrowMauler : Enemy
{
    public CrowMauler() : base("Crow Mauler", 70, 25) { }

    public override void InfoEnemy()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"HP: {Hp}");
        Console.WriteLine($"Damage: {Damage}");
        Console.WriteLine("Dapat menyerang dua kali per ronde, dan ketika kamu tidak memiliki senjata memberikan damage double");
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

    public override void Attack(int damage)
    {
        if (damage < 0) return;
        Console.WriteLine($"{Name} menyerang dengan cakarnya! memberikan {damage} damage!");
    }

    public void Attack(int damage, Player player)
    {
        if (damage < 0) return;
        if (player.EquippedWeapon != null)
        {
            Console.WriteLine($"{Name} menyerang dengan cakarnya! memberikan damage ganda sebesar {damage * 2} damage!");
        }
    }
}