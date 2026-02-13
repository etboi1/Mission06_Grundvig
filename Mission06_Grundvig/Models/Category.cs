using System.ComponentModel.DataAnnotations;

namespace Mission06_Grundvig.Models
{
    public enum Category
    {
        [Display(Name = "Action/Adventure")]
        ActionAdventure,
        Comedy,
        Drama,
        Family,
        [Display(Name = "Horror/Suspense")]
        HorrorSuspense,
        Miscellaneous,
        Telivision,
        VHS
    }
}
