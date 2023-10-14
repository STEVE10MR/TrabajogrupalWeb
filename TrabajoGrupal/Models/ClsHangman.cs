using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajoGrupal.Models
{
    public class ClsHangman
    {
        public string WordToGuess { get; set; }
        public string MaskedWord { get; set; }
        public string GuessedLetters { get; set; }
        public int AttemptsLeft { get; set; }
        public bool GameOver { get; set; }
        public bool Win { get; set; }
    }
}