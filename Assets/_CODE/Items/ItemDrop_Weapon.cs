using DiepMono.Characters;

namespace DiepMono.Items
{
    public class ItemDrop_Weapon : ItemDrop
    {
        public int WeaponID;

        public override void Collect(Character character)
        {
            character.WeaponController.UnlockWeapon(WeaponID);
            character.WeaponController.ReloadWeapons(WeaponID);
            base.Collect(character);
        }
    } 
}
