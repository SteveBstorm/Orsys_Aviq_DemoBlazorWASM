namespace DemoBlazorWASM.Pages.Exercices.Exo1
{
    public partial class Quizz
    {
        public string Nickname { get; set; }

        public List<string> Answers { get; set; }

        public List<string> Questions { get; set; }

        public int Counter { get; set; }

        protected override void OnInitialized()
        {
            Questions = new List<string>();
            Questions.Add("Avez vous bien mangé à midi ?");
            Questions.Add("Appréciez vous Blazor ?");
            Questions.Add("Petite sieste ?");

            Answers = new List<string>();
            Counter = 0;
        }

        public void SaveResponse(string resp)
        {
            Answers.Add(resp);
            Counter++;
        }

        public bool IsGameFinished { get; set; } = false;

        public void GameOver()
        {
            IsGameFinished = true;
        }
    }
}
