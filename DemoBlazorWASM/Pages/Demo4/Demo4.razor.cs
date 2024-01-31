namespace DemoBlazorWASM.Pages.Demo4
{
    public partial class Demo4
    {
        public List<Guid> Liste { get; set; }

        public Demo4()
        {
            Liste = new List<Guid>();
            for(int i = 0;  i < 50; i++) {
                Liste.Add(Guid.NewGuid());
            }
        }
    }
}
