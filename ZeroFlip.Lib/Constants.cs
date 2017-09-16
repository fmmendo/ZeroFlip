namespace ZeroFlip.Lib
{
    public class Constants
    {
        public static readonly string WinHeader = "You Won!";
        public static readonly string WinMessage = "Congratulations!, You've revealed all the multiplier tiles! {0}";

        public static readonly string LoseHeader = "You Lost!";
        public static readonly string LoseMessage = "Oh no! You lost! {0}Don't give up you can still rack up more points!";

        public static readonly string GiveUpHeader = "Too hard?";
        public static readonly string GiveUpMessage = "No problem, let's updated your score and generate a new board. ";

        public static readonly string LevelUpMessage = "You've moved up to level {0}! ";
        public static readonly string LevelDownMessage = "You've dropped down to level {0}. ";

        public static readonly string HowToPlayTitle = "HOW TO PLAY";
        public static readonly string HowToPlayStep1 = "The game grid is populated with numbers ranging from 0 to 3.";
        public static readonly string HowToPlayStep2 = "These numbers will be used as multipliers to calculate your final score.";
        public static readonly string HowToPlayStep3 = "2s and 3s will double and triple your score, while 1s have no effect.";
        public static readonly string HowToPlayStep4 = "You win the game when you reach the maximum score, and lose if your reveal a 0.";
        public static readonly string HowToPlayStep5 = "To help you in your game, the board provides you with a few hints.";
        public static readonly string HowToPlayStep6 = "The blue number indicates the sum of all the tiles in that row or column.";
        public static readonly string HowToPlayStep7 = "The red number indicates the number of Zeros.";
        public static readonly string HowToPlayStep8 = "For instace, this row has no zeros, so you can go ahead an reveal every tile!";
        public static readonly string HowToPlayStep9 = "But this column has 3 Zeros, so you need to be extra careful as only 2 tiles contain multipliers!";
        public static readonly string HowToPlayStep10 = "You can use the NOTES button to write down what numbers you expect to be in what tiles";
    }
}
