using System.ComponentModel.DataAnnotations;

namespace Mission06_Grundvig.Models
{
    public enum Category
    {
        Miscellaneous = 1,
        Drama,
        Telivision,
        [Display(Name = "Horror/Suspense")]
        HorrorSuspense,
        Comedy,
        Family,
        [Display(Name = "Action/Adventure")]
        ActionAdventure,
        VHS
    }
}
