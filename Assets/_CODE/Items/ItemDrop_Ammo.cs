using DiepMono.Characters;

namespace DiepMono.Items
{
    public class ItemDrop_Ammo : ItemDrop
    {
        public override void Collect(Character character)
        {
            character.WeaponController.ReloadWeapons();
            base.Collect(character);
        }
    } 
}
