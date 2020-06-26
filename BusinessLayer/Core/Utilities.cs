using System;
using System.Text.RegularExpressions;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using BusinessLayer.Core;
using BusinessLayer.DTO;
using System.Collections.Generic;

namespace Ajoor.BusinessLayer.Core
{
    static public class Utilities
    {
        public static string KEY = string.Empty;
        public static string USERNAME = string.Empty;
        public static bool RESTOREPASSWORD = false;
        public static string ERRORMESSAGE = "An error has occured! Please contact system developer!";
        public static string REMINDEROPTION_USEVOICE = "Use Voice";
        public static string REMINDEROPTION_USEDIALOG = "Use Dialog";
        public static SpeechRecognitionEngine engine;
        public static SpeechSynthesizer speaker;

        public static bool EnsureCurrencyOnly(string str)
        {
            int count = 0;
            foreach (char c in str)
            {
                if (char.IsDigit(c) || c == ',' || c == '.')
                    count++;
            }
            if (str.Length == count)
                return true;
            return false;
        }

        public static string CurrencyFormat(string str)
        {
            decimal value;
            if (decimal.TryParse(str, out value))
            {
                if (value == 0m)
                {
                    str = "0.00";
                }
                else
                {
                    str = value.ToString("#,#.00");
                }
            }
            else
            {
                str = string.Empty;
            }
            return str;
        }

        public static string RemoveCommasAndDots(string str)
        {
            string appendedForm = string.Empty;
            var splittedFormWithComma = str.Split(new string[] { "." }, StringSplitOptions.None)[0];
            var splittedFormWithoutComma = splittedFormWithComma.Split(new string[] { "," }, StringSplitOptions.None);
            for (int i = 0; i < splittedFormWithoutComma.Length; i++)
            {
                appendedForm += splittedFormWithoutComma[i];
            }
            return appendedForm;
        }

        public static bool EnsureNumericOnly(string str)
        {
            int count = 0;
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                    count++;
            }
            if (str.Length == count)
                return true;
            return false;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            email = email.Trim();
            var result = Regex.IsMatch(email, "^(?:[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+\\.)*[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!\\.)){0,61}[a-zA-Z0-9]?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\\[(?:(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\.){3}(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\]))$", RegexOptions.IgnoreCase);
            return result;
        }

        public static string GetMonthName(int monthNumber)
        {
            switch (monthNumber)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "December";
            }
        }

        public static void InitSpeaker()
        {
            speaker = new SpeechSynthesizer();
            speaker.Volume = 100;
            speaker.Rate = 1;
        }

        public static void InitEngine()
        {
            engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            engine.SetInputToDefaultAudioDevice();
            var grammer = CustomGrammar.MyGrammer();
            engine.LoadGrammar(grammer);
            engine.RecognizeAsync(RecognizeMode.Multiple);
            engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognition.engine_SpeechRecognized);
        }

        public static void DisposeEngine(SpeechRecognitionEngine engine)
        {
            engine.Dispose();
        }

        public static void DisposeSpeaker(SpeechSynthesizer speaker)
        {
            speaker.Dispose();
        }

        public static string GetLastDateOfPreviousMonth()
        {
            var previousMonthNumber = DateTime.Now.Month - 1;
            int numberOfDaysInCurrentMonth = 0; string dateInStringFormat = string.Empty;
            if (previousMonthNumber > 0)
            {
                numberOfDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1);
                dateInStringFormat = $"{numberOfDaysInCurrentMonth}-{DateTime.Now.Month - 1}-{DateTime.Now.Year}";
            }
            else
            {
                numberOfDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year - 1, 12);
                dateInStringFormat = $"{numberOfDaysInCurrentMonth}-{12}-{DateTime.Now.Year - 1}";
            }
            return dateInStringFormat;
        }

        public static List<Month> GetAllMonthsInAYear()
        {
            return new List<Month>
            {
                new Month(){Id=1, Name="January"},
                new Month(){Id=2, Name="February"},
                new Month(){Id=3, Name="March"},
                new Month(){Id=4, Name="April"},
                new Month(){Id=5, Name="May"},
                new Month(){Id=6, Name="June"},
                new Month(){Id=7, Name="July"},
                new Month(){Id=8, Name="August"},
                new Month(){Id=9, Name="September"},
                new Month(){Id=10, Name="October"},
                new Month(){Id=11, Name="November"},
                new Month(){Id=12, Name="December"},
            };
        }

        public static List<int> GetValidYears()
        {
            return new List<int>
            {
                2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027,
                2028, 2029, 2030
            };
        }

        public enum Modes
        {
            NonFlexible = 0,
            Flexible = 1
        }
    }
}
