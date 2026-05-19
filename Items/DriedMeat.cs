using OOP.Entites;

namespace OOP.Items;

class DriedMeat : Item
{
    public DriedMeat() : base("Dried Meat", 1) { DropRate = 10; }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine("Efek: Pulihkan 30 Hunger saat digunakan.");
    }

    public override void UseItem(Player player)
    {
        base.UseItem(player);
        player.DecreaseHunger(30);
    }
}