using DiepMono.Characters;

namespace DiepMono.Items
{
    public class ItemDrop_HP : ItemDrop
    {
        public override void Collect(Character character)
        {
            character.DamageComponent.Heal();
            base.Collect(character);
        }
    } 
}
