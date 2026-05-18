using OOP.Entites;

namespace OOP.Items;

class WineCup : Item
{
    public WineCup() : base("Wine Cup", 1) { DropRate = 20; }

    public override void ShowInfo()
    {
        Console.WriteLine($"Item: {Name}");
        Console.WriteLine("Efek: Pulihkan 20 Sanity tapi memberikan 15 Hunger saat digunakan.");
    }

    public override void UseItem(Player player)
    {
        base.UseItem(player);
        player.HealSanity(20);
        player.IncreaseHunger(15);
    }
}