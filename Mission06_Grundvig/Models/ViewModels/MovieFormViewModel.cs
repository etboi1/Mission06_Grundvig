using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Mission06_Grundvig.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        [ValidateNever]
        public List<Category> Categories { get; set; }
    }

}
