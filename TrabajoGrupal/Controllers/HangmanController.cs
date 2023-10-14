using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoGrupal.Models;
using System.Text;

namespace TrabajoGrupal.Controllers
{
    public class HangmanController : Controller
    {
        private static ClsHangman _hangman;

        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "Debe iniciar sesion para acceder a esta pagina";
                return RedirectToAction("Index", "Default");
            }
            _hangman = new ClsHangman
            {
                WordToGuess = GetRandomWord(),
                GuessedLetters = string.Empty,
                AttemptsLeft = 6,
                GameOver = false,
                Win = false
            };

            if (Session["Score"] == null)
            {
                Session["Score"] = 0;
            }

            _hangman.MaskedWord = MaskWord(_hangman.WordToGuess);

            return View(_hangman);
        }

        [HttpPost]
        public ActionResult Guess(char guess)
        {
            if (!_hangman.GameOver)
            {
                if (!_hangman.GuessedLetters.Contains(guess))
                {
                    _hangman.GuessedLetters += guess;

                    if (_hangman.WordToGuess.Contains(guess))
                    {
                        _hangman.MaskedWord = RevealLetter(_hangman.WordToGuess, _hangman.MaskedWord, guess);
                    }
                    else
                    {
                        _hangman.AttemptsLeft--;
                    }
                }

                _hangman.GameOver = _hangman.AttemptsLeft == 0 || !_hangman.MaskedWord.Contains('_');
                _hangman.Win = !_hangman.MaskedWord.Contains('_');

                if (_hangman.Win)
                {
                    Session["Score"] = (int)Session["Score"] + 1;
                }
            }

            return View("Index", _hangman);
        }

        private string MaskWord(string word)
        {
            return new string('_', word.Length);
        }

        private string RevealLetter(string word, string maskedWord, char letter)
        {
            StringBuilder updatedMaskedWord = new StringBuilder(maskedWord);

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {
                    updatedMaskedWord[i] = letter;
                }
            }

            return updatedMaskedWord.ToString();
        }

        private string GetRandomWord()
        {
            string[] words = new[] { "elefante", "girafa", "hipopotamo", "rinoceronte", "cocodrilo" };
            Random random = new Random();
            int index = random.Next(words.Length);
            return words[index];
        }
    }
}
