using OOP.Entites;

namespace OOP.Weapons;

class RustySword : Weapon
{
    public RustySword() : base("Rusty Sword", 35) { DropRate = 15; }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine("Efek Khusus: Memiliki kesempatan 20% patah saat digunakan.");
    }

    public override void Attack(Player player)
    {
        base.Attack(player);
        Random rand = new();
        int chance = rand.Next(0, 100);
        if (chance < 20)
        {
            Console.WriteLine($"Sial! {Name} patah saat digunakan!");
            player.EquippedWeapon = null;
            Lose(player);
        }
    }
}