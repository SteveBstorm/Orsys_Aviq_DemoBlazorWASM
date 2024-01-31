using Microsoft.AspNetCore.Components;

namespace DemoBlazorWASM.Pages.Demo1
{
    public partial class Demo1
    {
        public int Value { get; set; } = 42;
    
        public void Increment()
        {
            Value++;
        }

        public void Decrement(int nb)
        {
            Value -= nb;
        }
    }
}
