using OOP.Entites;

namespace OOP.Interface;

interface IWeapon
{
    int Damage { get; }
    void Attack(Player player);
}