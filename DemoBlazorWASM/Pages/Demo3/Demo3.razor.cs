using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoBlazorWASM.Pages.Demo3
{
    public partial class Demo3
    {
        //Pour validation en cascade d'objet complexe 
        //microsoft.aspnetcore.components.dataannotations.validation
        //Ajouter  [ValidateComplexType] sur l'objet a valider
        //Utiliser <ObjectGraphDataAnnotationsValidator /> à la place de <DataAnnotationsValidato />
        
        //Ne pas oublier de cocher Version préliminaire dans Nuget manager
        
        public Movie MyForm { get; set; }

        [Inject]
        public HttpClient Client { get; set; }

        protected override void OnInitialized()
        {
            MyForm = new Movie();
            MyForm.Realisator = new Person();
        }

        public async Task Submit()
        {
            await Client.PostAsJsonAsync("movie",MyForm);
            Console.WriteLine(MyForm.Title);
        }
        public void ForceRender()
        {
            StateHasChanged();
        }
    }
}
