namespace OOP.Entites;

class HabreCultist : Enemy
{
    public HabreCultist() : base("Habre Cultist", 80, 0) { }

    public override void InfoEnemy()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"HP: {Hp}");
        Console.WriteLine($"{Name} tidak dapat memberikan damage namun akan mengurangi sanity sebanyak 25 setiap round. Dan ketika sanity mu dibawah 30 {Name} akan menyembuhkan dirinya");
    }

    public void SpesialAbility(Player player)
    {
        player.LossSanity(25);
        if (player.Sanity < 30)
        {
            Heal(10);
        }
    }
}