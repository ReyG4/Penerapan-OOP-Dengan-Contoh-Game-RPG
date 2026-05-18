namespace OOP.SystemGame;

using OOP.Items;
using OOP.Weapons;

class DropItems
{
    List<Item> drafInventory =
    [
        new BandageRoll(),
        new DriedMeat(),
        new WineCup(),
        new BoneClub(),
        new RustySword(),
        new Torch()
    ];

    public Item RandomDropItem()
    {
        Random rnd = new();
        int total = 0;
        foreach (var draf in drafInventory)
            total += draf.DropRate;

        int roll = rnd.Next(1, total + 1);
        int cumulative = 0;

        foreach (var draf in drafInventory)
        {
            cumulative += draf.DropRate;
            if (roll <= draf.DropRate)
            {
                return draf;
            }
        }

        return drafInventory[0];
    }
}