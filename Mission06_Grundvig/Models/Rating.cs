using System.ComponentModel.DataAnnotations;

namespace Mission06_Grundvig.Models
{
    public enum Rating
    {
        G,
        PG,
        [Display(Name = "PG-13")]
        PG13,
        R
    }
}
