using System.ComponentModel.DataAnnotations;

namespace dungeon
{
    // For each session, a player must have a character which contains
    // essential character data
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Session Session { get; set; }       
        public int PlayerId { get; set; }
        public CharacterClass CharacterClass { get; set; }

        public int Constitution { get; set; }
        public int Charisma { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Wisdom { get; set; }

		public string Looks { get; set; }
		public int Armor { get; set; }
		public int Level { get; set; }
		public int XP { get; set; }
		public int Hitpoints { get; set; }
		public int Damage { get; set; }
		public string Alignment { get; set; }
		public string Race { get; set; }
		public string Gear { get; set; }
		public string Bonds { get; set; }
		public string Moves { get; set; }
		public string Spells { get; set; }
		public int Coin { get; set; }

        public int MaxHP() {
            return this.Constitution + this.CharacterClass.HPCalc;
        }
	}
}