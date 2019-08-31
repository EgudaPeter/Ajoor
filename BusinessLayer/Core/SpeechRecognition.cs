using Ajoor.BusinessLayer.Core;
using Ajoor.BusinessLayer.Repos;
using System;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace BusinessLayer.Core
{
    static class SpeechRecognition
    {
        public static void engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                string monthName = Utilities.getMonthName(DateTime.Now.Month);
                TransactionRepo _TransactionRepo = new TransactionRepo();
                switch (e.Result.Text)
                {
                    case "Yes":
                        if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month - 1))
                        {
                            return;
                        }
                        else
                        {
                            Utilities.speaker.Speak($"Alright {Utilities.USERNAME}. I am about to close the month. This might take some time.");
                            Utilities.speaker.Speak($"Please note that once the month has been closed, no postings will allowed anymore for the day.");
                            Utilities.speaker.Speak($"Closing month of {monthName}");
                            if (_TransactionRepo.CloseMonthOperation())
                            {
                                Utilities.speaker.Speak($"Month of {monthName} has been closed {Utilities.USERNAME}.");
                                Utilities.speaker.Speak($"Good bye.");
                            }
                            Utilities.DisposeSpeaker(Utilities.speaker);
                            Utilities.DisposeEngine(Utilities.engine);
                        }
                        break;
                    case "No":
                        Utilities.speaker.Speak($"Alright {Utilities.USERNAME}. But Please endeavour to close the month today");
                        Utilities.speaker.Speak($"Good bye.");
                        Utilities.DisposeSpeaker(Utilities.speaker);
                        Utilities.DisposeEngine(Utilities.engine);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utilities.DisposeSpeaker(Utilities.speaker);
                Utilities.DisposeEngine(Utilities.engine);
            }
        }
    }
}
