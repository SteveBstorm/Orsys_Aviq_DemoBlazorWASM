namespace DemoBlazorWASM.Pages.Demo2
{
    public partial class Demo2
    {
        public int MyValue { get; set; } = 10;

        public string ValueFromChildren { get; set; }
        public void ReceiveFromChildren(string s)
        {
            ValueFromChildren = s;
        }

        public void Increment()
        {
            MyValue++;
           
        }

        protected override bool ShouldRender()
        {
            if (MyValue == 15) return false;
            return true;
        }

        public Demo2()
        {
            Console.WriteLine("Contructeur");
        }
        protected override async Task OnInitializedAsync()
        {
            await Console.Out.WriteLineAsync("Passage dans la méthode Initialized");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Console.WriteLine("Premier rendu => chargement");
            }
            else
            {
                Render++;
                Console.WriteLine("Rendu nr " + Render);
            }
            
        }

        public int Render { get; set; }
    }
}
