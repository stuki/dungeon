namespace dungeon.Models
{
    // Classes the character can be
    public abstract class CharacterClass
    {
        public int Id { get; set; }

        public string ClassName { get; set; }

        // Comma separated list of scores available for stats in character creation
        public string Attributes { get; set; }

        // What constitution is added with for the hit points
        public int HPCalc { get; set; }

        // Dice rolled for damage'
        public string Damage { get; set; }

        // Json with default values for class
        public string Alignment { get; set; }

        // Json with default gear options for class
        public string StartingInventory { get; set; }

        // Json with default races for class
        public string Race { get; set; }

        // Json with default bonds for class
        public string Bonds { get; set; }

        // Json with class starting moves
        public string Startingmoves { get; set; }

        // Json with class leveling moves
        public string Advancedmoves { get; set; }

        // Json with class spells available for class
        public string SpellList { get; set; }
    }
}